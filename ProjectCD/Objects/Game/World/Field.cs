using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
using ProjectCD.Objects.Game.CDObject;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Servers.Game;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.World;
using static SunStructs.Definitions.Const;
using static SunStructs.Definitions.ItemResult;

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
                SendPlayerAllInfos(player);
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
            Logger.Instance.Log($"FieldItemKey[{fieldItem.GetKey()}]");
            fieldItem.SetOwner(player);
            fieldItem.SetItem(item);

            EnterField(fieldItem, SunVector.GetRandomPosAround(player.GetPos(), 2));
        }

        public ItemResult PlayerPickupItem(Player player, uint objectKey,out ItemSlotInfo[]? slotInfos)
        {
            slotInfos = null;
            if (!_activeObjects.TryGetValue(objectKey, out var obj)) return RC_ITEM_NOTEXISTITEMATFIELD;
            if (!(obj is FieldItem fieldItem)) return RC_ITEM_NOTEXISTITEMATFIELD;
            if (SunVector.GetDistance(obj.GetPos(), player.GetPos()) > DISTANCE_SPACE_GET_ITEM) return RC_ITEM_CANT_PICKABLE_BY_LENGTH;
            if (!fieldItem.CanPick(player)) return RC_ITEM_DONOT_HAVE_OWNERSHIP;

            if (fieldItem.IsMoney())
            {
                player.IncreaseMoney(fieldItem.GetMoney());
                return RC_ITEM_SUCCESS;
            }

            if (!player.GetInventory().InsertItem(fieldItem.GetItem()!,out slotInfos)) return RC_ITEM_NOSPACEININVENTORY;

            LeaveField(fieldItem);

            return RC_ITEM_SUCCESS;

        }

        public void SendPlayerAllInfos(Player player)
        {
            var itemRenderInfos = new List<ItemRenderInfo>();

            foreach (var activeObject in _activeObjects)
            {
                switch (activeObject.Value.GetObjectType())
                {
                    case ObjectType.ITEM_OBJECT:
                        var fieldItem = (FieldItem)activeObject.Value;
                        itemRenderInfos.Add(fieldItem.GetRenderInfo());
                        continue;
                }
            }

            SendAllFieldItemInfo(player,itemRenderInfos);

        }
        private void SendAllFieldItemInfo(Player player, List<ItemRenderInfo> allRenderInfos)
        {
            int count = allRenderInfos.Count;
            int currentIndex = 0;
            while (count > 0)
            {
                //Is allRenderInfos bigger than maxSize
                var amount = count> MAX_FIELDITEM_INFO_SIZE ? MAX_FIELDITEM_INFO_SIZE : count;
                count -= amount;

                var infos = new ItemRenderInfo[amount];

                allRenderInfos.CopyTo(infos);

                //if there are still more left, delete the ones that are send this iteration
                if (count > 0)
                {
                    allRenderInfos.RemoveRange(currentIndex, amount);
                    currentIndex += amount;
                }

                var outInfo = new AllFieldItemInfo(infos);
                var packet = new AllFieldItemInfoBrd(outInfo);
                player.SendPacket(packet);
            }
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
