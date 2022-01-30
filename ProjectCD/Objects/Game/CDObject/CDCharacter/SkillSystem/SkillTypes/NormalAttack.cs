using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Formulas;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Battle.Server;
using SunStructs.Packets.GameServerPackets.Battle;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes
{
    internal class NormalAttack : SkillBase
    {
        protected byte AttackSequence;
        protected Character Target;
        protected int Damage;
        protected int MainTargetDamage;
        private BaseStyleInfo _baseStyleInfo;

        public override void Init(Character owner, ref SkillInfo skillInfo, RootSkillInfo rootSkillInfo)
        {
            SetupDefault(owner,ref skillInfo,rootSkillInfo);
            AttackSequence = skillInfo.AttackSequence;
            _baseStyleInfo = (BaseStyleInfo) rootSkillInfo;

        }

        protected override void SetExecutionInterval()
        {
            Interval = 0;
        }

        public override SkillType GetSkillType()
        {
            return SkillType.SKILL_TYPE_NORMAL;
        }

        protected override bool CheckMainTarget(out BattleResult result)
        {
            result = BattleResult.RC_BATTLE_SUCCESS;
            Target = Field?.FindCharacter(SkillInfo.MainTargetKey);

            if (Target == null)
            {
                result = BattleResult.RC_BATTLE_INVALID_MAINTARGET;
                return false;
            }

            if (!Owner!.CheckSkillRange(Target, SkillInfo.MainTargetPosition))
            {
                result = BattleResult.RC_BATTLE_OUT_OF_RANGE;
                return false;
            }
            return true;
        }

        protected bool CalcDamage(Character target)
        {
            var damageArgs = new DamageArgs()
            {
                attacker = Owner,
                attackType = Owner.GetWeaponBaseAttackType()
            };
            damageArgs.Damage = CharacterFormulas.CalcNormalDamage(Owner, target, Owner.GetWeaponBaseAttackType(),
                Owner.GetWeaponMagicAttackType(), _baseStyleInfo.CriticalBonus, ref SkillInfo.SkillEffect,0);

            int addDamage = _baseStyleInfo.AddDamage[AttackSequence];
            float damagePercent = _baseStyleInfo.DamagePercent[AttackSequence];

            damageArgs.Damage = (int) (damageArgs.Damage * (1 + damagePercent) + addDamage);
            damageArgs.IsCrit = (SkillInfo.SkillEffect & Const.SKILL_EFFECT_CRITICAL) != 0;
            damageArgs.SDApply = SDApply.SD_APPLY_DO;

            target.Damaged(damageArgs);

            Damage = damageArgs.Damage;

            if (ApplyEtherBullet && EtherBulletInfo != null)
                SkillInfo.SkillEffect |= EtherBulletInfo.EffectCode;

            return damageArgs.Damage!=0;
        }

        public override bool StartExecute()
        {
            if (!CheckMainTarget(out var result))
            {
                return false;
            }

            if (Owner.IsFriend(Target) == UserRelationType.USER_RELATION_ENEMY && Target.CanBeAttacked())
            {
                Owner.ForcedAttack(Target);

                if (CalcDamage(Target))
                {
                    SendAIMessage(Target,(ushort) Damage);
                }

                Owner.GetStatusManager().UpdateExpireTime(CharStateType.CHAR_STATE_BATTLE,Const.STATE_BATTLE_TIME);
            }

            Owner.OnAttack(Target,Const.SKILLCODE_NORMAL_ATTACK,Damage);

            BroadcastNormalResult();
            return true;
        }

        private void BroadcastNormalResult()
        {
            var info = new PlayerNormalAttackBrdInfo(
                Owner.GetKey(),
                (AttackSequence) AttackSequence,
                SkillInfo.SkillCode,
                SkillInfo.ClientSerial,
                SkillInfo.MainTargetPosition,
                SkillInfo.MainTargetKey,
                (ushort)Damage,
                (uint) Target.GetHP(),
                SkillInfo.SkillEffect,
                (byte) EtherComboCount
            );
            var packet = new PlayerAttackBrd(info);
            Field.SendToAll(packet);
        }
    }
}
