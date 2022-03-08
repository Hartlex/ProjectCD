using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Battle.Client;
using SunStructs.PacketInfos.Game.Style.Server;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Battle;
using SunStructs.Packets.GameServerPackets.Style;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using static SunStructs.Packets.GameServerPackets.Battle.BattleProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal static class BattleActions
    {
        private static int _count;
        public static void Initialize()
        {
            RegisterBattleAction(ASK_PLAYER_ATTACK,OnAskPlayerAttack);
            Logger.Instance.LogOnLine($"[GAME][BATTLE] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private static void RegisterBattleAction(BattleProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.BATTLE, (byte)subType, action);
            _count++;
        }

        private static void OnAskPlayerAttack(ByteBuffer buffer, Connection connection)
        {
            var info = new AskPlayerAttackInfo(ref buffer);
            var skillInfo = new SkillInfo()
            {
                AttackSequence = info.StyleRef,
                ClientSerial = info.ClientSerial,
                CurrentPosition = info.CurrentPos,
                DestinationPosition = info.DestinationPos,
                MainTargetPosition = info.DestinationPos,
                MainTargetKey = info.TargetKey
            };
            //Logger.Instance.Log($"Current Pos= {info.CurrentPos}");
            //Logger.Instance.Log($"Target Pos= {info.DestinationPos}");
            var player = connection.User.Player;
            player.SetPos(info.CurrentPos);
            skillInfo.Owner = player;
            skillInfo.SkillCode = (ushort) player.GetCurrentStyleCode();
            skillInfo.RootSkillInfo = BaseSkillDB.Instance.GetBaseStyleInfo(skillInfo.SkillCode);
            player.SetAttackDelay((AttackSequence) skillInfo.AttackSequence, skillInfo.SkillCode);

            player.UseSkill(skillInfo);

            //ByteUtils.Print(buffer.GetData());

            //var outInfo = new ActionExpiredInfo(connection.User.UserID);
            //var packet = new ActionExpiredCmd(outInfo);
            //connection.Send(packet);


            //var outPacket = new StyleAttackBRD(new StylePlayerAttackInfo(
            //    connection.User.Player.GetKey(),
            //    info.StyleRef,
            //    (ushort) Style.STYLE_ONEHANDSWORD_NORMAL,
            //    info.ClientSerial,
            //    info.TargetKey,
            //    info.DestinationPos
            //));

            //connection.User.Player.GetCurrentField()?.SendToAll(outPacket);



            //for (int i = 190; i < 255 * 5; i++)
            //{
            //    var b = new ByteBuffer();
            //    b.WriteUInt32(connection.User.Player.GetKey());
            //    b.WriteByte(info.StyleRef);
            //    b.WriteUInt16((ushort)Style.STYLE_ONEHANDSWORD_NORMAL);
            //    b.WriteUInt32(0);
            //    b.WriteUInt32(info.TargetKey);
            //    info.CurrentPos.GetBytes(ref b);


            //    var testPacket = new TestPacket((byte)GamePacketType.STYLE, (byte) i, new TestPacketInfo(b.GetData()));
            //    connection.User.Player.GetCurrentField()?.SendToAll(testPacket);
            //    Logger.Instance.Log(i);

            //    Thread.Sleep(2000);
            //}
            //for (int i = 140; i < 255; i++)
            //{
            //    var b = new ByteBuffer();
            //    b.WriteUInt16(100);
            //    b.WriteByte(i);
            //    b.WriteUInt32(connection.User.Player.GetKey());
            //    b.WriteByte(info.StyleRef);
            //    //b.WriteUInt16((ushort)Style.STYLE_SPEAR_NORMAL);
            //    b.WriteUInt16((ushort)Style.STYLE_ONEHANDSWORD_NORMAL);
            //    b.WriteUInt32(info.ClientSerial);
            //    b.WriteUInt32(info.TargetKey);
            //    info.DestinationPos.GetBytes(ref b);

            //    var testPacket = new TestPacket((byte)GamePacketType.SYNC, (byte) SyncProtocol.WAR_MESSAGE,
            //        new TestPacketInfo(b.GetData()));

            //    connection.User.Player.GetCurrentField()?.SendToAll(testPacket);

            //    Logger.Instance.Log(i);
            //    Thread.Sleep(1000);
            //}


            //warpacket 140 moving to target and go into attackpos
            //    var b = new ByteBuffer();
            //    b.WriteUInt16(100);
            //    b.WriteByte(i);
            //    b.WriteUInt32(connection.User.Player.GetKey());
            //    b.WriteByte(info.StyleRef);
            //    b.WriteUInt16((ushort)Style.STYLE_ONEHANDSWORD_NORMAL);
            //    b.WriteUInt32(info.ClientSerial);
            //    b.WriteUInt32(info.TargetKey);
            //    info.CurrentPos.GetBytes(ref b);

            // Style 41 Result, dmg but no animation
            // var b = new ByteBuffer();
            //b.WriteUInt32(info.ClientSerial);
            //b.WriteUInt32(connection.User.Player.GetKey());
            //b.WriteByte(1);
            //b.WriteUInt32(info.TargetKey);
            //b.WriteUInt16(5);
            //b.WriteUInt32(20);
            //info.CurrentPos.GetBytes(ref b);
            //info.CurrentPos.GetBytes(ref b);
            //b.WriteByte(0);
            //b.WriteByte(0);
        }

    }

}
