using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Objects.Game.World;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects
{
    internal class BombEffect : BaseEffect
    {

    }

    internal class SelfDestructionDamageEffect : BaseEffect
    {
        private Step _checker;
        private Field _field;
        private const int TIMEOUT_LIFE_TIME = 10 * 1000;
        private SunTimeout _timer;
        private SelfDestructDamageInfo _destructionDamageInfo;

        public void SetInformation(Field field, SelfDestructDamageInfo info)
        {
            _field = field;
            _checker = Step.INIT;
            _destructionDamageInfo = info;
            _timer = new SunTimeout(DateTime.Now.AddMilliseconds(TIMEOUT_LIFE_TIME).Ticks);
        }
    }

    internal class SelfDestructDamageInfo
    {
        public int Damage;
        public DamageOpt Option;
    }
    internal enum DamageOpt
    {
        NONE=0,
        VALUE=1,
        RATIO=2
    }

    enum Step
    {
        INIT,
        EXECUTE,
        EXECUTED,
        RELEASE
    }
}
