using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Battle.Client;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Battle;
using SunStructs.Packets.GameServerPackets.Sync;
using static SunStructs.Packets.GameServerPackets.Battle.BattleProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal class BattleActions
    {
        private int _count;
        public BattleActions()
        {
            RegisterBattleAction(ASK_PLAYER_ATTACK,OnAskPlayerAttack);
            Logger.Instance.LogOnLine($"[GAME][BATTLE] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterBattleAction(BattleProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.BATTLE, (byte)subType, action);
            _count++;
        }

        private void OnAskPlayerAttack(ByteBuffer buffer, Connection connection)
        {
            //ByteUtils.Print(buffer.GetData());
            var info = new AskPlayerAttackInfo(ref buffer);
            Logger.Instance.Log($"Attack[{info.ClientSerial}][{info.StyleRef}]");
            var outInfo = new ActionExpiredInfo(connection.User.UserID);
            var packet = new ActionExpiredCmd(outInfo);
            connection.Send(packet);

            var b = new ByteBuffer();
            buffer.WriteUInt32(connection.User.Player.GetKey());
            buffer.WriteUInt16((ushort) Style.STYLE_DRAGON_PUNCH);
            buffer.WriteUInt16((ushort) Style.STYLE_ONEHANDSWORD_NORMAL);
            var testPacket = new TestPacket((byte)GamePacketType.STYLE, 95, new TestPacketInfo(b.GetData()));
            connection.User.Player.GetCurrentField()?.SendToAll(testPacket);


            b = new ByteBuffer();
            b.WriteUInt32(connection.User.Player.GetKey());
            b.WriteByte((byte)info.StyleRef);
            b.WriteUInt16((ushort) Style.STYLE_ONEHANDSWORD_NORMAL);
            b.WriteUInt32(info.ClientSerial);
            info.CurrentPos.GetBytes(ref b);
            b.WriteUInt32(info.TargetKey);
            b.WriteUInt16(5);
            b.WriteUInt32(20);
            b.WriteByte(0);
            b.WriteByte(0);

            testPacket = new TestPacket((byte) GamePacketType.BATTLE, 109, new TestPacketInfo(b.GetData()));
            connection.User.Player.GetCurrentField()?.SendToAll(testPacket);
            //for (int i = 0; i < 255; i++)
            //{
            //    var b = new ByteBuffer();
            //    b.WriteUInt16(1);
            //    b.WriteByte(i);
            //    b.WriteUInt32(connection.User.UserID);
            //    b.WriteByte(info.StyleRef);
            //    b.WriteUInt16((ushort) Style.STYLE_ONEHANDSWORD_NORMAL);
            //    b.WriteUInt32(info.ClientSerial);
            //    info.CurrentPos.GetBytes(ref b);
            //    b.WriteUInt32(info.TargetKey);
            //    b.WriteUInt16(5);
            //    b.WriteUInt32(95);
            //    b.WriteByte(0);
            //    b.WriteByte(0);

            //    var testPacket = new TestPacket((byte) GamePacketType.SYNC, (byte) SyncProtocol.WAR_MESSAGE,
            //        new TestPacketInfo(b.GetData()));

            //    connection.User.Player.GetCurrentField()?.SendToAll(testPacket);

            //    Logger.Instance.Log(i);
            //    Thread.Sleep(3000);
            //}
        }

    }

}
