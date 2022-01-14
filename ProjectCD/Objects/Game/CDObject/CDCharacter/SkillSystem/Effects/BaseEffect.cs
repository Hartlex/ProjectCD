using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects
{
    public class BaseEffect : BaseStatus
    {
        protected ushort SkillCode;
        protected Field? Field;
        protected uint SectorID;
        protected SunVector Position;
        protected float Radius;

        public void Init(ushort skillCode, int applicationTime, int period, Character attacker, SunVector position,
            float radius)
        {
            SkillCode = skillCode;
            Position = position;
            Radius = radius;

            Field = attacker.GetCurrentField();
            SectorID = attacker.GetSectorID();

            base.Init(attacker, GetStateType(),applicationTime,period);
        }
        public virtual void SetDamage(AttackType attackType, ushort damage){}
        public virtual void SetSkillPercentDamage(float skillPercentDamage){}
    }
}
