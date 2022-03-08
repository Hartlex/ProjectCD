using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Client;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem
{
    internal class SkillInfo
    {
        public Character Owner;
        public ushort SkillCode;
        public RootSkillInfo RootSkillInfo;
        public uint ClientSerial;
        public uint MainTargetKey;
        public SkillExtraOption SkillExtraOption;
        public byte AttackSequence;
        public byte StyleRepresentation;
        public byte AttackPropensity;
        public byte SkillFactor;
        public byte SkillEffect;
        public byte EventCode;
        public int SkillDelay;

        public SunVector CurrentPosition;
        public SunVector DestinationPosition;
        public SunVector MainTargetPosition;
        public SkillInfo(){}
        public SkillInfo(Player player, AskUseSkillInfo info)
        {
            Owner = player;
            ClientSerial = info.ClientSerial;
            MainTargetKey = info.TargetKey;
            AttackPropensity = info.AttackPropensity;
            SkillCode = info.SkillCode;
            CurrentPosition = info.CurrentPos;
            DestinationPosition = info.DestPos;
            MainTargetPosition = info.TargetPos;

        }
    }

    internal class SkillExtraOption
    {
        enum _optionType
        {
            Option_None = 0,
            Option_ForcedAttack = 1 << 0, // replaced by 'attack_propencity'
            // 1 << 1 - empty, enables runtime option
            // 1 << 2 - empty, enables runtime option
            //-------------------------------------------------------------------------
            // STATE_DETAIL_INFO::m_byAbilityIndex 5Bit [3, 7] = { 3,4,5,6,7 }
            // 1 << 3 - reserved, enables to store db
            // 1 << 4 - reserved, enables to store db
            Option_HoldupBuffPostDead = 1 << 5,
            // 1 << 6 - reserved, enables to store db
            // 1 << 7 - reserved, enables to store db
            Option_DBStoreRangeMask = (1 << 3) | (1 << 4) | (1 << 5) | (1 << 6) | (1 << 7),
            //-------------------------------------------------------------------------
        }

        private byte _option;

        public void ApplyOption(byte option) { _option = option; }
        public void ApplyOption(SkillExtraOption option) { _option = option._option; }
        public void AddOption(byte option) { _option |= option; }

        public bool HasOption(int value)
        {
            return (_option & value) != 0;
        }


    }

    internal class BonusAbilityEffect
    {
        public uint TargetKey;
        public int SkillAttackPower;
        public float SkillPercentDamage;

        public void Reset()
        {
            TargetKey = 0;
            SkillAttackPower = 0;
            SkillPercentDamage = 0;
        }
    }

    internal class DamageArgs
    {
        public Character attacker;
        public AttackType attackType;
        public bool IsCrit;
        public bool IsMirror;

        public int LimitHP;
        public AttackResist AttackResistKind;
        public SDApply SDApply;
        public int Damage;
        public ushort DamageFirst;


    }
}
