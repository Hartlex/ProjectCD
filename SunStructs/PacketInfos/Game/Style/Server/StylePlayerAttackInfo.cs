using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Style.Server
{
    public class StylePlayerAttackInfo : ServerPacketInfo
    {
        public uint AttackerObjId;
        public byte AttackType;
        public ushort StyleCode;
        public uint ClientSerial;
        public uint TargetObjId;
        public SunVector DestPos;

        public StylePlayerAttackInfo(uint attackerObjId, byte attackType, ushort styleCode,uint clientSerial, uint targetObjId, SunVector destPos)
        {
            AttackerObjId = attackerObjId;
            AttackType = attackType;
            StyleCode = styleCode;
            ClientSerial = clientSerial;
            TargetObjId = targetObjId;
            DestPos = destPos;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(AttackerObjId);
            buffer.WriteByte((byte)AttackType);
            buffer.WriteUInt16(StyleCode);
            buffer.WriteUInt32(ClientSerial);
            buffer.WriteUInt32(TargetObjId);
            DestPos.GetBytes(ref buffer);
        }

    }
}
