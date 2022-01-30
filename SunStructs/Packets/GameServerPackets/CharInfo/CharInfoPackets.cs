using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Connection.Server;
using SunStructs.PacketInfos.Game.Object.Character.Player;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace SunStructs.Packets.GameServerPackets.CharInfo
{
    public class CharInfoPacket : Packet
    {
        public CharInfoPacket(byte packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.CHAR_INFO, packetSubType, info)
        {
        }
    }
    public class NakDuplicateName : CharInfoPacket
    {
        public NakDuplicateName(AnsDuplicateNameInfo info) : base(45, info) { }
    }

    public class AckDuplicateName : CharInfoPacket
    {
        public AckDuplicateName(EmptyPacketInfo empty) : base(12, empty) { }
    }

    public class AckCreateCharacter : CharInfoPacket
    {
        public AckCreateCharacter(ClientCharacterPart info) : base(226, info) { }
    }

    public class NakCreateCharacter : CharInfoPacket
    {
        public NakCreateCharacter(NakCreateCharInfo info) : base(113, info) { }
    }

    public class AckDeleteCharacter : CharInfoPacket
    {
        public AckDeleteCharacter(EmptyPacketInfo info) : base(7, info) { }
    }

    public class NakDeleteCharacter : CharInfoPacket
    {
        public NakDeleteCharacter(NakDeleteCharacterInfo info) : base(162, info) { }
    }
    public class FullCharInfoCmd : CharInfoPacket
    {
        public FullCharInfoCmd(FullCharInfoZone info) : base(42, info) { }
    }
    public class PlayerSkillInfoCmd : CharInfoPacket
    {
        public PlayerSkillInfoCmd(FullSkillInfo info) : base(159, info) { }
    }

    public class PlayerQuickInfoCmd : CharInfoPacket
    {
        public PlayerQuickInfoCmd(TestPacketInfo bytes) : base(190, bytes) { }
    }

    public class PlayerStyleInfoCmd : CharInfoPacket
    {
        public PlayerStyleInfoCmd(TestPacketInfo bytes) : base(193, bytes) { }
    }

    public class PlayerStateInfoCmd : CharInfoPacket
    {
        public PlayerStateInfoCmd(TestPacketInfo bytes) : base(219, bytes) { }
    }
}
