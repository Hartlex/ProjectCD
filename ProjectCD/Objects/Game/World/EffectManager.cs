using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.World
{
    internal class EffectManager
    {
        private readonly Field _field;
        private readonly List<BaseEffect> _effects;

        public EffectManager(Field field)
        {
            _field = field;
            _effects = new(100);
        }

        public void Update(long currentTick)
        {
            foreach (var baseEffect in _effects.ToList())
            {
               
                if (baseEffect.Update(currentTick) == false)
                    _effects.Remove(baseEffect);
            }
        }

        public BaseEffect? AllocEffect(FieldeffectType type)
        {
            BaseEffect? effect = null;
            switch (type)
            {
                case FieldeffectType.EFFECT_TYPE_PERIODIC_DAMAGE:
                    effect = new PeriodicDamageEffect();
                    break;
                case FieldeffectType.EFFECT_TYPE_BOMB:
                    effect = new BombEffect();
                    break;
                case FieldeffectType.EFFECT_TYPE_SELF_DESTRUCTION:
                    effect = new SelfDestructionDamageEffect();
                    break;
                case FieldeffectType.EFFECT_TYPE_PERIODIC_SKILL:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            effect.SetStateID((CharStateType) type);
            _effects.Add(effect);

            return effect;
        }

    }
}
