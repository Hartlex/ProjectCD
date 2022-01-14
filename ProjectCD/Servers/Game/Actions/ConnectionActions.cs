using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.DB;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Connection;
using SunStructs.PacketInfos.Game.Connection.Client;
using SunStructs.PacketInfos.Game.Connection.Server;
using SunStructs.PacketInfos.Game.Quest.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.CharInfo;
using SunStructs.Packets.GameServerPackets.Connection;
using SunStructs.Packets.GameServerPackets.Quest;
using SunStructs.ServerInfos.General.Object.Character.Player;

namespace ProjectCD.Servers.Game.Actions
{
    internal class ConnectionActions
    {
        private int _count;
        public ConnectionActions()
        {
            RegisterConnectionAction(118,OnAskEnterCharSelect);
            RegisterConnectionAction(31, OnAskEnterGame);
            RegisterConnectionAction(223,OnHeartbeat);
            Logger.Instance.LogOnLine($"[GAME][CONNECTION] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterConnectionAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.CONNECTION, subType, action);
            _count++;
        }


        private void OnAskEnterCharSelect(ByteBuffer buffer, Connection connection)
        {
            var info = new AskEnterCharSelectInfo(ref buffer);
            if (ServerManager.Instance.TryEnterGameServer(info, connection, out var user,out var worldServer))
            {
                UserManager.Instance.AddUser(user,AddUserType.FROM_GAME);
                connection.AppendCloseHandler((con) =>
                {
                    UserManager.Instance.RemoveUser(user,RemoveUserType.FROM_GAME);

                });

                var charInfos = user.GetCharacters();
                var outInfo = new AckEnterCharSelectInfo(user.UserID, charInfos);
                var packet = new AckEnterCharSelect(outInfo);
                connection.Send(packet);

                var worldIP = worldServer.GetLocalEndPoint().Address.ToString();
                var port = worldServer.GetLocalEndPoint().Port;
                ConnectToWorldInfo worldInfo = new(worldIP, port);
                var worldPacket = new ConnectToWorldCmd(worldInfo);
                connection.Send(worldPacket);

            }
        }

        private void OnAskEnterGame(ByteBuffer buffer, Connection connection)
        {
            var info = new AskEnterGameInfo(ref buffer);

            var player = Database.Instance.CreatePlayerFromDB(connection.User, info.CharSlot);
            connection.AppendCloseHandler(player.OnDisconnect);
            connection.User.SelectCharacter(player);


            var fullInfo = player.GetFullCharInfoZone();
            var charPacket = new FullCharInfoCmd(fullInfo);

            var skillPacket = new PlayerSkillInfoCmd(new TestPacketInfo(new byte[] { 0 }));
            var quickPacket = new PlayerQuickInfoCmd(new TestPacketInfo(new byte[] { 0 }));
            var stylePacket = new PlayerStyleInfoCmd(new TestPacketInfo(new byte[] { 0 }));
            var statePacket = new PlayerStateInfoCmd(new TestPacketInfo(new byte[] { 0 }));
            var questPacket = new QuestListCmd(
                new QuestListInfo(Array.Empty<FinishedQuestInfo>(),
                    Array.Empty<OngoingQuestInfo>()));
            var enterGamePacket = new AckEnterGame(new AckEnterGameInfo(connection.User.UserID));

            connection.Send(charPacket, skillPacket, quickPacket, stylePacket, statePacket, questPacket, enterGamePacket);

        }

        private void OnHeartbeat(ByteBuffer buffer, Connection connection)
        {

        }

    }
}
