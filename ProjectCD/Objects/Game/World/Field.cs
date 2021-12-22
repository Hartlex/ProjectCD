﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
using ProjectCD.Objects.Game.CDObject;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Servers.Game;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.World;
using static SunStructs.Definitions.Const;

namespace ProjectCD.Objects.Game.World
{
    public class Field
    {
        private readonly BaseFieldInfo _baseFieldInfo;
        private readonly GameServer _server;
        private readonly Dictionary<uint, Player> _activePlayers;
        private readonly Dictionary<uint, ObjectBase> _activeObjects;
        public Field(BaseFieldInfo baseFieldInfo, GameServer server)
        {
            _baseFieldInfo = baseFieldInfo;
            _server = server;
            _activePlayers = new(MAX_PLAYERS_ON_MAP);
            _activeObjects = new(MAX_OBJECTS_ON_MAP);
        }

        public virtual bool EnterField(ObjectBase obj, SunVector pos, ushort angle = 0)
        {
            var pSuccess = true;
            if (obj is Player player)
            {
                pSuccess = _activePlayers.TryAdd(player.GetKey(), player);
#if DEBUG
                Logger.Instance.Log($"Player[{player.GetKey()}] joined Field[{_baseFieldInfo.MapCode}]");
#endif
            } 
            var oSuccess = _activeObjects.TryAdd(obj.GetKey(), obj) && pSuccess;

            obj.OnEnterField(this,pos);
            return oSuccess && pSuccess;
        }

        public virtual bool LeaveField(ObjectBase obj)
        {
            if (obj is Player player)
            {
                _activePlayers.Remove(player.GetKey());
#if DEBUG
                Logger.Instance.Log($"Player[{player.GetKey()}] left Field[{_baseFieldInfo.MapCode}]");
#endif
            }
            obj.OnLeaveField();
            return _activeObjects.Remove(obj.GetKey());
        }

        public void SendToAllBut(MoveSyncBrd packet,Player player)
        {
            foreach (var activePlayer in _activePlayers.Values)
            {
                activePlayer.SendPacket(packet);
            }
        }

        public void DropItemFromPlayer(Player player, Item item)
        {
            var fieldItem = (FieldItem) ObjectFactory.Instance.CreateObject(ObjectType.ITEM_OBJECT)!;
            fieldItem.SetOwner(player);
            fieldItem.SetItem(item);

            EnterField(fieldItem, SunVector.GetRandomPosAround(player.GetPos(), 2));
        }

        public void Broadcast(Packet packet)
        {
            foreach (var player in _activePlayers.Values)
            {
                player.SendPacket(packet);
            }
        }
    }

    public class GameField : Field
    {
        public GameField(BaseFieldInfo baseFieldInfo, GameServer server) : base(baseFieldInfo, server)
        {
        }
    }
}
