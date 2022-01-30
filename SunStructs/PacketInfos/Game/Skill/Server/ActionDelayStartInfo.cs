using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class ActionDelayStartInfo : SkillActionResult
    {
        public SunVector CurrentPos;
        public SunVector DestPos;

        //public ActionDelayStartInfo(ushort skillCode, uint clientSerial, uint attackerObjKey, uint primeTargetObjKey, SunVector primeTargetPosition, SunVector currentPosition, SunVector destinationPosition) : base(skillCode, clientSerial, attackerObjKey, primeTargetObjKey, primeTargetPosition)
        //{
        //    CurrentPosition = currentPosition;
        //    DestinationPosition = destinationPosition;
        //}

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            CurrentPos.GetBytes(ref buffer);
            DestPos.GetBytes(ref buffer);
        }


    }
    public class ActionDelayResultInfo : SkillActionResult
    {
        public uint AttackerHP;
        public uint AttackerMP;
        public byte NumberOfTargets;
        public byte NumberOfFieldEffects;
        public SkillResultBase[] SkillResults;
        
        //public ActionDelayResultInfo(ushort skillCode, uint clientSerial, uint attackerObjKey, uint primeTargetObjKey, SunVector primeTargetPosition, uint attackerHP, uint attackerMP, byte numberOfTargets, byte numberOfFieldEffects) : base(skillCode, clientSerial, attackerObjKey, primeTargetObjKey, primeTargetPosition)
        //{
        //    AttackerHP = attackerHP;
        //    AttackerMP = attackerMP;
        //    NumberOfTargets = numberOfTargets;
        //    NumberOfFieldEffects = numberOfFieldEffects;
        //    SkillResults = new SkillResultBase[numberOfTargets];
        //}
        
        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(AttackerHP);
            buffer.WriteUInt32(AttackerMP);
            byte b = 0;
            b = BitManip.Set0to5(b, NumberOfTargets);
            b = BitManip.Set6to7(b, NumberOfFieldEffects);
            buffer.WriteByte(b);

            foreach (var skillResultBase in SkillResults)
            {
                skillResultBase.GetBytes(ref buffer);
            }
            
            
        }


    }
}
