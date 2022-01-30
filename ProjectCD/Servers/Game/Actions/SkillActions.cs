using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Client;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Skill;
using static SunStructs.Packets.GameServerPackets.Skill.SkillProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal static class SkillActions
    {
        private static int _count;
        public static void Initialize()
        {
            RegisterSkillAction(ASK_INCREASE_SKILL,OnAskIncreaseSkill);
            RegisterSkillAction(ASK_USE_SKILL,OnAskUseSkill);

            Logger.Instance.LogOnLine($"[GAME][SKILL] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private static void RegisterSkillAction(SkillProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.SKILL, (byte)subType, action);
            _count++;
        }

        private static void OnAskIncreaseSkill(ByteBuffer buffer, Connection connection)
        {
            var player = connection.User.Player;
            var info = new AskIncreaseSkillInfo(ref buffer);
            if (player.TryLevelUpSkill(info, out var resultInfo) == SkillResult.RC_SKILL_SUCCESS)
            {
                var packet = new AckIncreaseSkill(resultInfo!);
                connection.Send(packet);
                return;
            }

        }

        private static void OnAskUseSkill(ByteBuffer buffer, Connection connection)
        {
            var info = new AskUseSkillInfo(ref buffer);
            var player = connection.User.Player;

            var skillInfo = new SkillInfo(player,info);

            player.UseSkill(skillInfo);
        }
    }
}
