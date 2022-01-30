using System.ComponentModel.DataAnnotations;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Style.Server
{
    public class StylePlayerAttackResultInfo :ServerPacketInfo
    {
        public uint ClientSerial;
        public uint AttackerObjId;
        public byte NumberOfTargets;
        public StyleAttackResult[] AttackResults;

        public StylePlayerAttackResultInfo(uint clientSerial, uint attackerObjId)
        {           
            ClientSerial = clientSerial;
            AttackerObjId = attackerObjId;
            NumberOfTargets = 0;
            AttackResults = new StyleAttackResult[Const.MAX_TARGET_COUNT];
        }
        public StylePlayerAttackResultInfo(uint clientSerial, uint attackerObjId, byte numberOfTargets, StyleAttackResult[] attackResults)
        {
            ClientSerial = clientSerial;
            AttackerObjId = attackerObjId;
            NumberOfTargets = numberOfTargets;
            AttackResults = attackResults;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ClientSerial);
            buffer.WriteUInt32(AttackerObjId);
            buffer.WriteByte(NumberOfTargets);
            for (var i = 0; i < NumberOfTargets; i++)
            {
                AttackResults[i].GetBytes(ref buffer);
            }
        }
    }

    public class StyleAttackResult : ServerPacketInfo
    {
        public uint TargetObjId;
        public ushort Damage;
        public uint TargetHP;
        public SunVector CurPos;
        public SunVector DestPos;
        public byte SkillEffect;
        public byte EtherEffect;

        public StyleAttackResult(uint targetObjId, ushort damage, uint targetHP, SunVector curPos, SunVector destPos)
        {
            TargetObjId = targetObjId;
            Damage = damage;
            TargetHP = targetHP;
            CurPos = curPos;
            DestPos = destPos;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(TargetObjId);
            buffer.WriteUInt16(Damage);
            buffer.WriteUInt32(TargetHP);
            CurPos.GetBytes(ref buffer);
            DestPos.GetBytes(ref buffer);
            buffer.WriteByte(SkillEffect);
            buffer.WriteByte(EtherEffect);
        }
    }
}
