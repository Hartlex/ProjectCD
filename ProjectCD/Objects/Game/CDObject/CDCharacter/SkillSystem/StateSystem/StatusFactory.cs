using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.StatusPoolIndex;
using static SunStructs.Definitions.CharStateType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem
{
    enum StatusPoolIndex
    {
        //-----------------------------
        SPI_BASESTATUS = 0,

        //-----------------------------
        // AbilityBase -> BaseStatus
        SPI_ABILITYSTATUS,

        //-----------------------------
        // AbilityBase derived status
        SPI_WOUNDSTATUS,
        SPI_STUNSTATUS,
        SPI_ABSORBSTATUS,
        SPI_CURESTATUS,
        SPI_BLINDSTATUS,
        SPI_MAGICSHIELDSTATUS,
        SPI_FEARSTATUS,
        SPI_SPBONUSSTATUS,
        SPI_CHAOSSTATUS,
        SPI_WINDSHIELDSTATUS,
        SPI_MIRRORSTATUS,
        SPI_THRUSTSTATUS,
        SPI_SLEEPSTATUS,
        SPI_LOWHPSTATUS,
        SPI_BONUSDAMAGESTATUS,
        SPI_DRAGONTRANSSTATUS,
        SPI_SUMMONSTATUS,
        SPI_INCOMPETENCESTATUS, // CHANGUP_IMPOSSIBLE_ATTCAK_STATUS
        SPI_INTENSIFYSUMMON, // CHANGUP_RECKLESS_STATUS
        SPI_SUCTIONSTATUS,
        SPI_CHANGE_ATTR,
        SPI_TRANSPARENT,
        SPI_VITALSUCTION_STATUS,
        SPI_ENCHANTPOISON_STATUS,
        SPI_SHELDPOINTSTATUS,

        //-----------------------------
        // EtcStatus -> BaseStatus
        // EtcStatus derived status
        SPI_STYLETHRUST,
        SPI_STYLESTUN,
        SPI_STYLEDOWN,
        SPI_RECOVERSTATUS,
        SPI_STEELSTATUS,
        SPI_BATTLESTATUS,

        //-----------------------------
        SPI_TOGGLEFPSTATUS,
        SPI_AUTOCASTBYATTACK,
        SPI_OVERLAPSTATUS,

        // Upperbound
        SPI_SIZE_MAX
    }

    internal class StatusFactory : Singleton<StatusFactory>
    {


        private Dictionary<CharStateType, StatusPoolIndex> _statusMatchMap = new()
        {
            { CHAR_STATE_POISON, SPI_WOUNDSTATUS},
            { CHAR_STATE_WOUND, SPI_WOUNDSTATUS},
            { CHAR_STATE_FIRE_WOUND, SPI_WOUNDSTATUS},
            { CHAR_STATE_PERIODIC_DAMAGE, SPI_WOUNDSTATUS},

            { CHAR_STATE_STUN, SPI_STUNSTATUS },
            { CHAR_STATE_DOWN, SPI_STUNSTATUS },
            { CHAR_STATE_UPPERDOWN, SPI_STUNSTATUS },
            { CHAR_STATE_DELAY, SPI_STUNSTATUS },
            { CHAR_STATE_FROZEN, SPI_STUNSTATUS },
            { CHAR_STATE_HOLDING, SPI_STUNSTATUS },

            { CHAR_STATE_ABSORB, SPI_ABSORBSTATUS },
            { CHAR_STATE_IMMUNITY_DAMAGE, SPI_ABSORBSTATUS },
            { CHAR_STATE_CURE, SPI_CURESTATUS },
            { CHAR_STATE_BLIND, SPI_BLINDSTATUS },
            { CHAR_STATE_POLYMORPH, SPI_BLINDSTATUS },
            { CHAR_STATE_MAGIC_SHIELD, SPI_MAGICSHIELDSTATUS },

            { CHAR_STATE_FEAR, SPI_FEARSTATUS },
            { CHAR_STATE_MP_FEAR2, SPI_FEARSTATUS },
            { CHAR_STATE_SP_BONUS, SPI_SPBONUSSTATUS },
            { CHAR_STATE_CHAOS, SPI_CHAOSSTATUS },
            { CHAR_STATE_BUF_RANGE_DAMAGE, SPI_WINDSHIELDSTATUS },
            { CHAR_STATE_BUF_RANGE_DAMAGE2, SPI_WINDSHIELDSTATUS },
            { CHAR_STATE_BUF_RANGE_DAMAGE3, SPI_WINDSHIELDSTATUS },
            { CHAR_STATE_BUF_RANGE_DAMAGE4, SPI_WINDSHIELDSTATUS },
            { CHAR_STATE_REFLECT_DAMAGE, SPI_MIRRORSTATUS },
            { CHAR_STATE_REFLECT_SLOW, SPI_MIRRORSTATUS },
            { CHAR_STATE_REFLECT_FROZEN, SPI_MIRRORSTATUS },
            { CHAR_STATE_REFLECT_SLOWDOWN, SPI_MIRRORSTATUS },
            { CHAR_STATE_REFLECT_STUN, SPI_MIRRORSTATUS },
            { CHAR_STATE_REFLECT_FEAR, SPI_MIRRORSTATUS },

            { CHAR_STATE_THRUST, SPI_THRUSTSTATUS },
            { CHAR_STATE_SLEEP, SPI_SLEEPSTATUS },
            { CHAR_STATE_STAT_LOWHP_ATTACK_DECREASE, SPI_LOWHPSTATUS },
            { CHAR_STATE_STAT_LOWHP_DEFENSE_DECREASE, SPI_LOWHPSTATUS },
            { CHAR_STATE_STAT_LOWHP_ATTACK_INCREASE, SPI_LOWHPSTATUS },
            { CHAR_STATE_STAT_LOWHP_DEFENSE_INCREASE, SPI_LOWHPSTATUS },
            { CHAR_STATE_STAT_DAMAGE_ADD, SPI_BONUSDAMAGESTATUS },
            { CHAR_STATE_STYLE_THRUST, SPI_STYLETHRUST },
            { CHAR_STATE_STYLE_STUN, SPI_STYLESTUN },
            { CHAR_STATE_STYLE_DOWN, SPI_STYLEDOWN },

            { CHAR_STATE_ETC_AUTO_RECOVER_HP, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_AUTO_RECOVER_MP, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_AUTO_RECOVER_HPMP, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_AUTO_RECOVER_SD, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_AUTO_RECOVER_FP, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_EXIST_SHELD_POINT, SPI_SHELDPOINTSTATUS },
            { CHAR_STATE_ETC_ITEM_RECOVER_HP, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_ITEM_RECOVER_HP_INSTANTLY, SPI_RECOVERSTATUS },
            { CHAR_STATE_ETC_ITEM_RECOVER_MP, SPI_RECOVERSTATUS },

            { CHAR_STATE_STEEL, SPI_STEELSTATUS },
            { CHAR_STATE_TRANSFORMATION, SPI_DRAGONTRANSSTATUS },
            { CHAR_STATE_SUMMON, SPI_SUMMONSTATUS },
            { CHAR_STATE_ATTACK_IMPOSSIBLE, SPI_INCOMPETENCESTATUS },
            { CHAR_STATE_INTENSIFY_SUMMON, SPI_INTENSIFYSUMMON },
            { CHAR_STATE_STUN2, SPI_STUNSTATUS },
            { CHAR_STATE_CURSE_INCREASE, SPI_ABILITYSTATUS },
            { CHAR_STATE_PAIN, SPI_WOUNDSTATUS },
            { CHAR_STATE_FIRE_WOUND2, SPI_WOUNDSTATUS },
            { CHAR_STATE_PAIN2, SPI_WOUNDSTATUS },
            { CHAR_STATE_HP_SUCTION, SPI_SUCTIONSTATUS },
            { CHAR_STATE_MP_SUCTION, SPI_SUCTIONSTATUS },
            { CHAR_STATE_CHANGE_ATTR, SPI_CHANGE_ATTR },
            { CHAR_STATE_TRANSPARENT, SPI_TRANSPARENT },
            { CHAR_STATE_VITAL_SUCTION, SPI_VITALSUCTION_STATUS },
            { CHAR_STATE_BATTLE, SPI_BATTLESTATUS },
            { CHAR_STATE_ENCHANT_POISON, SPI_ENCHANTPOISON_STATUS },
            { CHAR_STATE_POISON2, SPI_WOUNDSTATUS },
            { CHAR_STATE_ELECTRICSHOCK, SPI_WOUNDSTATUS },

            { kCharStateIncreaseHeal, SPI_ABILITYSTATUS },
            { kCharStateActiveComboSkill, SPI_ABILITYSTATUS },
            { kCharStateIncreseSkillDamage, SPI_ABILITYSTATUS },

            { CHAR_STATE_PHOENIX_BURN, SPI_WOUNDSTATUS },
            { CHAR_STATE_DARK_OF_LIGHT_ZONE, SPI_BLINDSTATUS },
            { CHAR_STATE_FATAL_POINT, SPI_STUNSTATUS },
            { CHAR_STATE_FUGITIVE, SPI_ABILITYSTATUS }
        };

        public BaseStatus? AllocStatus(CharStateType type, bool isAbility)
        {
            var spi = _statusMatchMap.ContainsKey(type) ? _statusMatchMap[type] :
                isAbility ? SPI_ABILITYSTATUS : SPI_BASESTATUS;
            switch (spi)
            {
                case SPI_BASESTATUS:
                    return new BaseStatus();
                case SPI_ABILITYSTATUS:
                    return new AbilityStatus();
                case SPI_WOUNDSTATUS:
                    return new WoundStatus();
                case SPI_STUNSTATUS:
                    return new StunStatus();
                case SPI_ABSORBSTATUS:
                    return new AbilityStatus();
                case SPI_CURESTATUS:
                    return new CureStatus();
                case SPI_BLINDSTATUS:
                    return new BlindStatus();
                case SPI_MAGICSHIELDSTATUS:
                    return new MagicShieldStatus();
                case SPI_FEARSTATUS:
                    return new FearStatus();
                case SPI_SPBONUSSTATUS:
                    return new SpBonusStatus();
                case SPI_CHAOSSTATUS:
                    return new ChangeAttrStatus();
                case SPI_WINDSHIELDSTATUS:
                    return new WindShieldStatus();
                case SPI_MIRRORSTATUS:
                    return new MirrorStatus();
                case SPI_THRUSTSTATUS:
                    return new ThrustStatus();
                case SPI_SLEEPSTATUS:
                    return new SleepStatus();
                case SPI_LOWHPSTATUS:
                    return new LowHPStatus();
                case SPI_BONUSDAMAGESTATUS:
                    return new BonusDamageStatus();
                case SPI_DRAGONTRANSSTATUS:
                    return new DragonTransStatus();
                case SPI_SUMMONSTATUS:
                    Logger.Instance.Log($"Unknown Status[SPI_SUMMONSTATUS]");
                    return new BaseStatus();
                case SPI_INCOMPETENCESTATUS:
                    return new IncompetenceStatus();
                case SPI_INTENSIFYSUMMON:
                    Logger.Instance.Log($"Unknown Status[SPI_INTENSIFYSUMMON]");
                    return new BaseStatus();
                case SPI_SUCTIONSTATUS:
                    return new SuctionStatus();
                case SPI_CHANGE_ATTR:
                    return new ChangeAttrStatus();
                case SPI_TRANSPARENT:
                    Logger.Instance.Log($"Unknown Status[SPI_TRANSPARENT]");
                    return new BaseStatus();
                case SPI_VITALSUCTION_STATUS:
                    Logger.Instance.Log($"Unknown Status[SPI_VITALSUCTION_STATUS]");
                    return new BaseStatus();
                case SPI_ENCHANTPOISON_STATUS:
                    return new EnchantPoisonStatus();
                case SPI_SHELDPOINTSTATUS:
                    return new ShieldPointStatus();
                case SPI_STYLETHRUST:
                    return new StyleThrustStatus();
                case SPI_STYLESTUN:
                    return new StyleStunStatus();
                case SPI_STYLEDOWN:
                    return new StyleDownStatus();
                case SPI_RECOVERSTATUS:
                    return new RecoverStatus();
                case SPI_STEELSTATUS:
                    return new SteelStatus();
                case SPI_BATTLESTATUS:
                    return new BattleStatus();
                case SPI_TOGGLEFPSTATUS:
                    Logger.Instance.Log($"Unknown Status[SPI_TOGGLEFPSTATUS]");
                    return new BaseStatus();
                case SPI_AUTOCASTBYATTACK:
                    Logger.Instance.Log($"Unknown Status[SPI_AUTOCASTBYATTACK]");
                    return new BaseStatus();
                case SPI_OVERLAPSTATUS:
                    Logger.Instance.Log($"Unknown Status[SPI_OVERLAPSTATUS]");
                    return new BaseStatus();
                case SPI_SIZE_MAX:
                    break;
                default:
                    return null;
            }

            return null;
        }

        
    }

    internal class StatusManagerBits
    {
        private readonly Dictionary<CharStateType, int> _cantAttackStates = new()
        {
            { CHAR_STATE_DOWN, 1 << 0 },
            { CHAR_STATE_DELAY, 1 << 1 },
            { CHAR_STATE_STUN, 1 << 2 },
            { CHAR_STATE_STONE, 1 << 3 },
            { CHAR_STATE_SLEEP, 1 << 4 },
            { CHAR_STATE_FROZEN, 1 << 5 },
            { CHAR_STATE_BLUR, 1 << 6 },
            { CHAR_STATE_BLUR_TRIGGER, 1 << 7 },
            { CHAR_STATE_STEEL, 1 << 8 },
            { CHAR_STATE_THRUST, 1 << 9 },
            { CHAR_STATE_ETC_RETURNING, 1 << 10 },
            { CHAR_STATE_SUMMON, 1 << 11 },
            { CHAR_STATE_FEAR, 1 << 12 },
            { CHAR_STATE_MP_FEAR2, 1 << 13 },
            { CHAR_STATE_ATTACK_IMPOSSIBLE, 1 << 14 },
            { CHAR_STATE_WAR_CTRL_OBSERVER_MODE, 1 << 15 },
            { CHAR_STATE_RIDING_RIDER, 1 << 16 },
            { CHAR_STATE_ZONE_TRANSACTION, 1 << 17 },
            { CHAR_STATE_FATAL_POINT, 1 << 18 },
            { CHAR_STATE_POLYMORPH, 1 << 19 },
            { CHAR_STATE_UPPERDOWN, 1 << 20 },
            { CHAR_STATE_CHARMED, 1 << 21 },


        };

        private readonly Dictionary<CharStateType, int> _cantBeAttackedStates = new()
        {
            { CHAR_STATE_STONE, 1 << 0 },
            { CHAR_STATE_STEEL, 1 << 1 },
            { CHAR_STATE_ETC_DISABLE_VISION, 1 << 2 },
            { CHAR_STATE_ETC_DISABLE_VISION_TRIGGER, 1 << 3 },
            { CHAR_STATE_SSQ_CTRL_BLOCK_ATTACK, 1 << 4 },
            { CHAR_STATE_WAR_CTRL_OBSERVER_MODE, 1 << 5 },
            { CHAR_STATE_ETC_RETURNING, 1 << 6 },
            { CHAR_STATE_ZONE_TRANSACTION, 1 << 7 },

        };

        private readonly Dictionary<CharStateType, int> _cantMoveStates = new()
        {
            { CHAR_STATE_DOWN, 1 << 0 },
            { CHAR_STATE_DELAY, 1 << 1 },
            { CHAR_STATE_STUN, 1 << 2 },
            { CHAR_STATE_STONE, 1 << 3 },
            { CHAR_STATE_SLEEP, 1 << 4 },
            { CHAR_STATE_FROZEN, 1 << 5 },
            { CHAR_STATE_HOLDING, 1 << 6 },
            { CHAR_STATE_THRUST, 1 << 7 },
            { CHAR_STATE_ETC_FORCED_WARP, 1 << 8 },
            { CHAR_STATE_SUMMON, 1 << 9 },
            { CHAR_STATE_FEAR, 1 << 10 },
            { CHAR_STATE_MP_FEAR2, 1 << 11 },
            { CHAR_STATE_WAR_CTRL_OBSERVER_MODE, 1 << 12 },
            { CHAR_STATE_ETC_TRIGGER_HOLDING, 1 << 13 },
            { CHAR_STATE_ZONE_TRANSACTION, 1 << 14 },
            { CHAR_STATE_FATAL_POINT, 1 << 15 },
            { CHAR_STATE_UPPERDOWN, 1 << 16 },
            { CHAR_STATE_CHARMED, 1 << 17 },
        };

        private readonly Dictionary<CharStateType, int> _cantUseSkill = new()
        {
            { CHAR_STATE_SEALING, 1 << 0 },
            { CHAR_STATE_CONFUSE, 1 << 1 },
            { CHAR_STATE_WAR_CTRL_OBSERVER_MODE, 1 << 2 },
            { CHAR_STATE_ZONE_TRANSACTION, 1 << 3 },
        };

        private readonly Dictionary<CharStateType, int> _exclusiveActionStates = new()
        {
            { CHAR_STATE_RIDING_RIDER, 1 << 0 }
        };

        private int _cantAttackField;
        private int _cantBeAttackedField;
        private int _cantMoveField;
        private int _cantUseSkillField;
        private int _exclusiveActionField;

        
        public StatusManagerBits()
        {
            _cantAttackField = 0;
            _cantBeAttackedField = 0;
            _cantMoveField = 0;
            _cantUseSkillField = 0;
            _exclusiveActionField = 0;
        }

        public bool CanAttack()
        {
            return _cantAttackField == 0;
        }

        public void AddRestrictStatus(CharStateType stateType)
        {
            SetField(stateType, _cantAttackStates,      ref _cantAttackField);
            SetField(stateType, _cantBeAttackedStates,  ref _cantBeAttackedField);
            SetField(stateType, _cantMoveStates,        ref _cantMoveField);
            SetField(stateType, _cantUseSkill,          ref _cantUseSkillField);
            SetField(stateType, _exclusiveActionStates, ref _exclusiveActionField);
        }
        public void RemoveRestrictStatus(CharStateType stateType)
        {
            RemoveField(stateType, _cantAttackStates,      ref _cantAttackField);
            RemoveField(stateType, _cantBeAttackedStates,  ref _cantBeAttackedField);
            RemoveField(stateType, _cantMoveStates,        ref _cantMoveField);
            RemoveField(stateType, _cantUseSkill,          ref _cantUseSkillField);
            RemoveField(stateType, _exclusiveActionStates, ref _exclusiveActionField);
        }

        private void SetField(CharStateType type, Dictionary<CharStateType, int> dict, ref int field)
        {
            if (dict.ContainsKey(type))
                field |= dict[type];
        }

        private void RemoveField(CharStateType type, Dictionary<CharStateType, int> dict, ref int field)
        {
            if(dict.ContainsKey(type))
                field &= ~dict[type];
        }
    }


}
