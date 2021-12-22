using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Sync.Client;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Sync;

namespace ProjectCD.Servers.Game.Actions
{
    internal class SyncActions
    {
        private int _count;
        public SyncActions()
        {
            RegisterSyncAction(141,AskEnterField);
            RegisterSyncAction(43,OnKeyboardMove);
            RegisterSyncAction(115, OnJump);
            RegisterSyncAction(202, OnMouseMove);
            RegisterSyncAction(69, OnJumpEnd);
            RegisterSyncAction(123, OnMoveStop);
            Logger.Instance.LogOnLine($"[GAME][SYNC] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterSyncAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.SYNC, subType, action);
            _count++;
        }

        private void AskEnterField(ByteBuffer buffer, Connection connection)
        {
            var checksum = buffer.ReadBlock(16);
            var player = connection.User.Player;
            if (!connection.User.GetConnectedGameServer().GetField(player.GetCurrentMapCode())
                    .EnterField(player, player.GetPos()))
            {
                return;
            }
            var guildPacket = new AllPlayersGuildInfoCmd(new TestPacketInfo(new byte[1]));
            var equipPacket = new AllPlayersEquipInfoCmd(new TestPacketInfo(new byte[1]));
            var enterPacket = new AckEnterWorld(new AckEnterWorldInfo(connection.User.Player.GetPos()));

            connection.Send(guildPacket, equipPacket, enterPacket);
        }

        private void OnKeyboardMove(ByteBuffer buffer, Connection connection)
        {
            var info = new KeyBoardMoveInfo(ref buffer);
            connection.User.Player.OnKeyboardMove(info);
            
        }

        private void OnJump(ByteBuffer buffer, Connection connection)
        {
            var info = new JumpInfo(ref buffer);
            connection.User.Player.OnJump(info);

            connection.User.Player.GetCurrentField()?.SendPlayerAllInfos(connection.User.Player);
        }

        private void OnMouseMove(ByteBuffer buffer, Connection connection)
        {
            var info = new MouseMoveInfo(ref buffer);
            connection.User.Player.OnMouseMove(info);

        }

        private void OnJumpEnd(ByteBuffer buffer, Connection connection)
        {
            var info = new AfterJumpInfo(ref buffer);
            connection.User.Player.OnAfterJump(info);
        }

        private void OnMoveStop(ByteBuffer buffer, Connection connection)
        {
            var info = new MoveStopInfo(ref buffer);
            connection.User.Player.OnMoveStop(info);
        }
    }
}
