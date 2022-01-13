using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private bool _doingAction;
        private SunTimer _actionTimer;


        public void PlayerSkillInit(ref SqlDataReader reader)
        {
            _doingAction = false;
            _actionTimer = new ();
        }
        public void SetActionDelay(long delay)
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
        public long GetActionDelay(){ return _actionTimer.GetIntervalTime(); }
        public bool IsActionExpired() { return _actionTimer.IsExpired(); }

        public void SetAttackDelay(AttackSequence attackSequence, ushort styleCode)
        {
            BaseStyleInfo styleInfo = BaseSkillDB.Instance.GetBaseStyleInfo(styleCode);

            long delay = 0;
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

            delay = (long) (delay * 0.9f);
            var attackSpeed = GetPhysicalAttackSpeed();
            if (attackSpeed != 0)
            {
                SetActionDelay((long) (delay / attackSpeed));
            }
            else
            {
                Logger.Instance.Log($"Player[{GetKey()}][SetAttackDelay] has an attack speed of 0!",LogType.ERROR);
            }
        }

    }
}
