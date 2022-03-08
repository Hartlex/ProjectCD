using ProjectCD.Formulas;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using static SunStructs.Definitions.CharStateType;
using static SunStructs.Definitions.RecoverType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    internal class RecoverStatus : EtcStatus
    {
        private int _regenHP;
        private int _regenMP;
        private bool _usePet;


        public override void Init(Character owner, CharStateType stateType, int applicationTime, int period)
        {
            _regenHP = 0;
            _regenMP = 0;
            _usePet = false;
            base.Init(owner, stateType, applicationTime, period);
        }

        public override void Start()
        {
            base.Start();
            Execute();
        }

        public void SetUsePet(bool usePet)
        {
            _usePet = usePet;
        }
        private bool IsUsePet()
        {
            return _usePet;
        }
        private bool IsHPRecover()
        {
            switch (GetStateType())
            {
                case CHAR_STATE_ETC_AUTO_RECOVER_HPMP:
                case CHAR_STATE_ETC_AUTO_RECOVER_HP:
                case CHAR_STATE_ETC_ITEM_RECOVER_HP:
                case CHAR_STATE_ETC_ITEM_RECOVER_HP_INSTANTLY:
                    return true;
            }

            return false;
        }

        private bool IsItemRecover()
        {
            switch (GetStateType())
            {
                case CHAR_STATE_ETC_ITEM_RECOVER_HP:
                case CHAR_STATE_ETC_ITEM_RECOVER_HP_INSTANTLY:
                case CHAR_STATE_ETC_ITEM_RECOVER_MP:
                    return true;
            }

            return false;
        }
        private bool IsMPRecover()
        {
            switch (GetStateType())
            {
                case CHAR_STATE_ETC_AUTO_RECOVER_HPMP:
                case CHAR_STATE_ETC_AUTO_RECOVER_MP:
                case CHAR_STATE_ETC_ITEM_RECOVER_MP:
                    return true;
            }

            return false;
        }

        private bool IsSDRecover()
        {
            return GetStateType() == CHAR_STATE_ETC_AUTO_RECOVER_SD;
        }

        private bool IsIgnoreReserveHP()
        {
            var owner = GetOwner();
            if (owner == null) return false;
            if (owner.IsObjectType(ObjectType.PLAYER_OBJECT) && owner is Player player)
            {
                if (IsUsePet() ||
                    player.GetStatusManager().FindStatus(CHAR_STATE_IGNORE_RESERVEHP) ||
                    player.GetStatusManager().FindStatus(CHAR_STATE_IGNORE_RESERVEHP2) ||
                    player.GetStatusManager().FindStatus(CHAR_STATE_IGNORE_RESERVEHP3) ||
                    player.GetStatusManager().FindStatus(CHAR_STATE_IGNORE_RESERVEHP4) ||
                    player.GetStatusManager().FindStatus(CHAR_STATE_IGNORE_RESERVEHP5) ||
                    player.GetStatusManager().FindStatus(CHAR_STATE_IGNORE_RESERVEHP6))
                {
                    return true;
                } 
            }

            return false;
        }

        public override void SetRegenInfo(int regenHp=0 , int regenMp=0)
        {
            _regenHP = regenHp;
            _regenMP = regenMp;
        }

        public override void Execute()
        {
            base.Execute();

            var owner = GetOwner();
            if (owner == null) return;

            int regenHP;
            int regenMP;
            if( GetStateType() is 
               CHAR_STATE_ETC_ITEM_RECOVER_HP or 
               CHAR_STATE_ETC_ITEM_RECOVER_MP or
               CHAR_STATE_ETC_ITEM_RECOVER_HP_INSTANTLY
               )
            {
                regenHP = _regenHP;
                regenMP = _regenMP;
            }
            else
            {
                regenHP = owner.GetRegenHP();
                regenMP = owner.GetRegenMP();
            }

            if (owner.IsAlive())
            {
                if (IsHPRecover())
                {
                    if (IsItemRecover())
                    {
                        var addValue = CharacterFormulas.CalcIncreaseHeal(IncreaseHealAbilityType.ITEM, regenHP, owner);
                        regenHP += addValue;
                    }

                    if (GetStateType() is CHAR_STATE_ETC_AUTO_RECOVER_HP or CHAR_STATE_ETC_AUTO_RECOVER_HPMP)
                    {
                        owner.OnRecover(regenHP, 0, 0,
                            IsIgnoreReserveHP() ? RECOVER_TYPE_IGNORE_RESERVE_HP : RECOVER_TYPE_AUTO_HP);
                    }
                    else
                        owner.OnRecover(regenHP, 0,0);
                }

                if (IsMPRecover())
                {
                    owner.OnRecover(0,regenMP,0);
                }

                if (IsSDRecover())
                {
                    owner.UpdateCalcRecover(false,false,true);
                    owner.OnRecover(0,0,owner.GetRegenSD());
                }
            }
            

        }

        public override bool CanRemove()
        {
            return IsItemRecover();
        }
    }

}
