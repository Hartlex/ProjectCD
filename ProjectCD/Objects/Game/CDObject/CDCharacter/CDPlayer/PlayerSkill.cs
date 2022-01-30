using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Skill;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using ProjectCD.Objects.Game.Slots.Skill;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Client;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.SkillResult;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private bool _doingAction;
        private SunTimer _actionTimer;
        private SkillContainer _skillContainer;
        private PlayerSkillManager _skillManager;
        private ushort _skillPoints;
        private ushort _statPoints;


        #region Initialization
        public void PlayerSkillInit(ref SqlDataReader reader)
        {
            _skillContainer = new((byte[])reader[41]);
            _doingAction = false;
            _actionTimer = new();
            _statPoints = (ushort) reader.GetInt32(23);
            _skillPoints = (ushort) reader.GetInt32(24);
            var selectedStyle = (ushort) reader.GetInt32(25);
            _skillManager = new(this, _skillContainer, _quickSlots,selectedStyle);
        }

        #endregion


        public byte[] GetFullSkillInfo()
        {
            return _skillContainer.Serialize();
        }
        public void SetActionDelay(int delay)
        {
            _actionTimer.SetTimer(delay);
            if (delay > 0)
            {
                _doingAction = true;
            }
            else if (_doingAction)
            {
                _doingAction = false;
                var packet = new ActionExpiredCmd(new(GetKey()));
                SendPacket(packet);
            }
        }
        public int GetActionDelay(){ return _actionTimer.GetIntervalTime(); }
        public ushort GetSkillPoints(){ return _skillPoints; }
        public ushort GetStatPoints(){ return _statPoints; }
        public bool IsActionExpired() { return _actionTimer.IsExpired(); }

        public bool IsDoingAction()
        {
            return _doingAction;
        }
        public void SetAttackDelay(AttackSequence attackSequence, ushort styleCode)
        {
            BaseStyleInfo styleInfo = BaseSkillDB.Instance.GetBaseStyleInfo(styleCode);

            int delay = 0;
            switch (attackSequence)
            {
                case AttackSequence.ATTACK_SEQUENCE_FIRST:
                    delay = styleInfo.TimeFirst;
                    break;
                case AttackSequence.ATTACK_SEQUENCE_SECOND:
                    delay = styleInfo.TimeSecond;
                    break;
                case AttackSequence.ATTACK_SEQUENCE_THIRD:
                    delay = styleInfo.TimeThird;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackSequence), attackSequence, null);
            }

            delay = (int) (delay * 0.9f);
            var attackSpeed = GetPhysicalAttackSpeed();
            if (attackSpeed != 0)
            {
                SetActionDelay( (int) (delay / attackSpeed));
            }
            else
            {
                Logger.Instance.Log($"Player[{GetKey()}][SetAttackDelay] has an attack speed of 0!",LogType.ERROR);
            }
        }

        public void TransOff()
        {
            
        }

        public bool UseSkill(SkillInfo info)
        {
            var baseInfo = BaseSkillDB.Instance.GetRootSkillInfo(info.SkillCode);
            if (baseInfo.IsSkill() && baseInfo is BaseSkillInfo baseSkillInfo)
            {
                info.RootSkillInfo = baseSkillInfo;
                ActiveSkillManager.RegisterSkill(baseSkillInfo.SkillType, ref info);
                return true;
            }
            else if (baseInfo.IsStyle())
            {
                //attackSequence
                ActiveSkillManager.RegisterSkill(SkillType.SKILL_TYPE_NORMAL, ref info);
                return true;
            }

            return false;
        }

        public bool CheckClassDefine(BaseSkillInfo skillInfo, bool activeSkill)
        {
            return true;
        }

        #region PacketActions

        public SkillResult TryLevelUpSkill(AskIncreaseSkillInfo info, out AckIncreaseSkillInfo? resultInfo)
        {
            SkillResult result;
            resultInfo = null;
            SkillSlotInfo? slotInfo;

            //Update existing Skill
            if (_skillContainer.HasSkill(info.SkillCode, out var rootInfo)) 
            {
                //Skill
                if (info.IsSkill == 1) 
                {
                    result = _skillManager.CanLevelUpSkill(info.SkillCode, out var newSkillInfo);
                    if (result != RC_SKILL_SUCCESS) return result;

                    _skillManager.LevelUpSkill(info.SkillCode,newSkillInfo!,out slotInfo);
                    _skillPoints -= newSkillInfo!.RequireSkillPoint; //Check already performed in CanLevelUpSkill
                    resultInfo = new (info.SkillCode, slotInfo, (ushort)_skillPoints);
                    return RC_SKILL_SUCCESS;
                }

                //Style
                result = _skillManager.CanLevelUpStyle(info.SkillCode, out var newStyleInfo);
                if (result != RC_SKILL_SUCCESS) return result;

                _skillManager.LevelUpStyle(info.SkillCode,newStyleInfo!,out slotInfo);
                _skillPoints -= newStyleInfo!.RequireSkillPoint; //Check already performed in CanLevelUpStyle
                resultInfo = new (info.SkillCode, slotInfo, (ushort)_skillPoints);
                return RC_SKILL_SUCCESS;
            }

            //New Skill

            //Skill
            if (info.IsSkill == 1) 
            {
                var skillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(info.SkillCode);
                result = _skillManager.CanLearnSkill(skillInfo);
                if (result != RC_SKILL_SUCCESS) return result;

                _skillManager.LearnSkill(info.SkillCode, out slotInfo);
                _skillPoints -= skillInfo.RequireSkillPoint; //Check already performed in CanLevelUpSkill
                resultInfo = new(info.SkillCode, slotInfo, (ushort)_skillPoints);
                return RC_SKILL_SUCCESS;
            }

            //Style
            var styleInfo = BaseSkillDB.Instance.GetBaseStyleInfo(info.SkillCode);
            result = _skillManager.CanLearnStyle(styleInfo);
            if (result != RC_SKILL_SUCCESS) return result;

            _skillManager.LearnStyle(info.SkillCode, out slotInfo);
            _skillPoints -= styleInfo.RequireSkillPoint; //Check already performed in CanLearnStyle
            resultInfo = new(info.SkillCode, slotInfo, (ushort)_skillPoints);
            return RC_SKILL_SUCCESS;

        }

        #endregion
    }
}
