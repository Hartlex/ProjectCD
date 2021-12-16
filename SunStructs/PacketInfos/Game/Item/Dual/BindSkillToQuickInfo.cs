using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Dual
{
    public class BindSkillToQuickInfo : DualPacketInfo
    {
        public readonly ushort SkillCode;
        public readonly byte QuickPos;
        public BindSkillToQuickInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            SkillCode = buffer.ReadUInt16();
            QuickPos = buffer.ReadByte();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(SkillCode);
            buffer.WriteByte(QuickPos);
        }
    }
}
