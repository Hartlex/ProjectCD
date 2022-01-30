using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class InstantSkillResultInfo : SkillActionResult
    {
        public SunVector CurrentPos;
        public SunVector DestPos;
        public uint AttackerHP;
        public uint AttackerMP;
        public byte NumberOfTargets;
        public byte NumberOfFieldEffects;
        public SkillResultBase[] SkillResults;
        

        //public InstantSkillResultInfo(ushort skillCode, uint clientSerial, uint attackerObjKey, uint primeTargetObjKey, SunVector primeTargetPosition, SunVector currentPos, SunVector destPos, uint attackerHP, uint attackerMP, byte numberOfTargets,byte numberOfFieldEffects) : base(skillCode, clientSerial, attackerObjKey, primeTargetObjKey, primeTargetPosition)
        //{
        //    CurrentPos = currentPos;
        //    DestPos = destPos;
        //    AttackerHP = attackerHP;
        //    AttackerMP = attackerMP;
        //    NumberOfTargets = numberOfTargets;
        //    NumberOfFieldEffects = numberOfFieldEffects;
        //    SkillResults = new SkillResultBase[numberOfTargets];
        //}

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            CurrentPos.GetBytes(ref buffer);
            DestPos.GetBytes(ref buffer);
            buffer.WriteUInt32(AttackerHP);
            buffer.WriteUInt32(AttackerMP);
            byte b = 0;
            b = BitManip.Set0to5(b, NumberOfTargets);
            b = BitManip.Set6to7(b, NumberOfFieldEffects);
            buffer.WriteByte(b);

            for (var i = 0; i < NumberOfTargets; i++)
            {
                SkillResults[i].GetBytes(ref buffer);
            }


            //buffer.WriteUInt32(PrimeTargetObjKey);
            //var b2 = (byte)0;
            //b2 = BitManip.Set0(b2, 0);//skill effekt
            //b2 = BitManip.Set1(b2, 0);
            //b2 = BitManip.Set2(b2, 0);
            //b2 = BitManip.Set3(b2, 0);
            //b2 = BitManip.Set4(b2, 0);
            //b2 = BitManip.Set5(b2, 1);//maybe number of status to add
            //b2 = BitManip.Set6(b2, 0);//num
            //b2 = BitManip.Set7(b2, 0);//num
            //buffer.WriteByte(b2);

            ////status
            //buffer.WriteBlock(new byte[]
            //{
            //    0,0

            //});
            //eSTATE_TYPE
            //buffer.WriteUInt16(0);
            //buffer.WriteUInt16(2);
            //buffer.WriteUInt32(65536);
            //buffer.WriteBlock(CurrentPos.GetBytes());




        }
    }

    public class SkillActionResult : ServerPacketInfo
    {
        public ushort SkillCode;
        public uint ClientSerial;
        public uint AttackerObjKey;
        public uint PrimeTargetObjKey;
        public SunVector PrimeTargetPosition;

        //public SkillActionResult(ushort skillCode, uint clientSerial, uint attackerObjKey, uint primeTargetObjKey, SunVector primeTargetPosition)
        //{
        //    SkillCode = skillCode;
        //    ClientSerial = clientSerial;
        //    AttackerObjKey = attackerObjKey;
        //    PrimeTargetObjKey = primeTargetObjKey;
        //    PrimeTargetPosition = primeTargetPosition;
        //}

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(SkillCode);
            buffer.WriteUInt32(ClientSerial);
            buffer.WriteUInt32(AttackerObjKey);
            buffer.WriteUInt32(PrimeTargetObjKey);
            PrimeTargetPosition.GetBytes(ref buffer);
        }
    }
}
