using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes
{
    internal class DelayedSkill : Skill
    {
        protected override void SetExecutionInterval()
        {
            int castingTime = GetBaseSkillInfo()!.SkillCasting;
            if (castingTime != 0)
            {
                var bonusCastingTime = Owner.GetAttributes()[AttrType.ATTR_BONUS_CASTING_TIME].GetValue();
                var bonusCastingRatio = Owner.GetAttributes()[AttrType.ATTR_BONUS_CASTING_TIME].GetRatio() / 100f;
                bonusCastingRatio = SunCalc.Min(-1f, bonusCastingRatio);

                castingTime = castingTime + bonusCastingTime;
                castingTime = SunCalc.Min(0, castingTime);
                castingTime = castingTime * 1 + bonusCastingTime;
            }

            Interval = castingTime + GetBaseSkillInfo()!.FlyingLifeTime + SkillInfo.SkillDelay;
            Logger.Instance.Log(Interval);
        }

        public override SkillType GetSkillType()
        {
            return SkillType.SKILL_TYPE_ACTIVE_DELAYED;
        }

        public override bool StartExecute()
        {
            if (Field == null) return false;

            if (!CheckMainTarget(out var battleResult))
                DidMiss = true;

            var delayInfo = new ActionDelayStartInfo();
            delayInfo.SkillCode = SkillInfo.SkillCode;
            delayInfo.ClientSerial = SkillInfo.ClientSerial;
            delayInfo.AttackerObjKey = Owner.GetKey();
            delayInfo.PrimeTargetObjKey = SkillInfo.MainTargetKey;
            delayInfo.PrimeTargetPosition = SkillInfo.MainTargetPosition;
            delayInfo.CurrentPos = SkillInfo.CurrentPosition;
            delayInfo.DestPos = SkillInfo.DestinationPosition;

            var packet = new SkillDelayStartBRD(delayInfo);
            Field.SendToAll(packet);

            return true;
        }

        public override void EndExecute()
        {
            if (Field == null) return;

            if (!CheckMainTarget(out var battleResult))
                DidMiss = true;

            InitResultMsg();

            if (DidMiss)
            {
                DecreaseHPMP();
                BroadCastDelayedResult();
                base.EndExecute();
                return;
            }

            DecreaseHPMP();

            base.ExecuteSkill();

            BroadCastDelayedResult();

            base.EndExecute();

            return;
        }
    }
}
