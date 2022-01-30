using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Battle.Server
{
    public class PlayerNormalAttackBrdInfo :ServerPacketInfo
    {
        public uint AttackerObjId;
        public AttackSequence AttackType;
        public ushort StyleCode;
        public uint ClientSerial;
        public SunVector CurrentPos;
        public uint TargetObjId;
        public ushort Damage;
        public uint TargetHp;
        public byte SkillEffect;
        public byte EtherEffect;

        public PlayerNormalAttackBrdInfo(uint attackerObjId, AttackSequence attackType, ushort styleCode, uint clientSerial, SunVector currentPos, uint targetObjId, ushort damage, uint targetHp, byte skillEffect, byte etherEffect)
        {
            AttackerObjId = attackerObjId;
            AttackType = attackType;
            StyleCode = styleCode;
            ClientSerial = clientSerial;
            CurrentPos = currentPos;
            TargetObjId = targetObjId;
            Damage = damage;
            TargetHp = targetHp;
            SkillEffect = skillEffect;
            EtherEffect = etherEffect;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(AttackerObjId);
            buffer.WriteByte((byte)AttackType);
            buffer.WriteUInt16(StyleCode);
            buffer.WriteUInt32(ClientSerial);
            CurrentPos.GetBytes(ref buffer);
            buffer.WriteUInt32(TargetObjId);
            buffer.WriteUInt16(Damage);
            buffer.WriteUInt32(TargetHp);
            buffer.WriteByte(SkillEffect);
            buffer.WriteByte(EtherEffect);

        }
    }
}
