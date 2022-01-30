using CDShared.Logging;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class AttackState : NpcState
    {
        //private Timer _actionDelayTimer;
        //private Timer _fallApartTimer;
        //private Timer _retreatTimer;
        //private bool _actionExpired;
        //private bool _fallApartExpired;
        //private bool _retreatExpired;

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);

        //    Owner.StopMoving();

        //    SetTimers();

        //}

        //private void SetTimers()
        //{
        //    SetActionTimer(10);
        //    SetFallApartTimer(2000);
        //    SetRetreatTimer(AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType).RetreatPeriod);
        //}
        //private void SetActionTimer(double interval)
        //{
        //    _actionExpired = false;
        //    _actionDelayTimer = new Timer(interval);
        //    _actionDelayTimer.Elapsed += (sender, args) => _actionExpired = true;
        //    _actionDelayTimer.AutoReset = false;
        //    _actionDelayTimer.Start();
        //}
        //private void SetFallApartTimer(double interval)
        //{
        //    _fallApartExpired = false;
        //    _fallApartTimer = new Timer(interval);
        //    _fallApartTimer.Elapsed += (sender, args) => _fallApartExpired = true;
        //    _fallApartTimer.AutoReset = false;
        //    _fallApartTimer.Start();
        //}
        //private void SetRetreatTimer(double interval)
        //{
        //    _retreatExpired = false;
        //    _retreatTimer = new Timer(interval);
        //    _retreatTimer.Elapsed += (sender, args) => _retreatExpired = true;
        //    _retreatTimer.AutoReset = false;
        //    _retreatTimer.Start();
        //}
        

        //public override void OnUpdate(long tick)
        //{
        //    base.OnUpdate(tick);

        //    if (!_actionExpired) return;
        //    var target = Owner.GetMainTarget();

        //    if (target == null || target.IsDead() || target.CurrentMap == null)
        //    {
        //        Owner.SetMainTarget(null);
        //        Owner.ChangeState((uint) STATE_ID_WANDER);
        //        return;
        //    }

        //    if (!target.CanBeAttacked())
        //    {
        //        Owner.ChangeState((uint)STATE_ID_WANDER);
        //        return;
        //    }

        //    if (!Owner.CanAttack()) return;
        //    if(Owner.GetSelectedSkill() == 0)
        //        Owner.SelectSkill();

        //    var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);
        //    if (Owner.GetDistToTarget() >= Owner.GetAttackRange() )
        //    {
        //        Owner.ChangeState((uint) STATE_ID_TRACK);
        //        return;
        //    }

        //    if (_fallApartExpired && Owner.IsToCloseToTarget())
        //    {
        //        if (Owner.CanFallApartFromTarget())
        //        {
        //            Owner.ChangeState((uint) STATE_ID_FALL_APART);
        //            return;
        //        }
        //    }

        //    if (_retreatExpired && Owner.NeedToRetreatFromTarget())
        //    {
        //        Owner.ChangeState((uint) STATE_ID_RETREAT);
        //    }
            
        //    DoAction();
            
        //}
        //private void DoAction()
        //{
        //    var selectedSkillCode = Owner.GetSelectedSkill();
        //    if (selectedSkillCode == 8100) //Skillcode NormalAttack
        //    {
        //        DoNormalAttack();
        //        Owner.ResetSelectedSkill();
        //    }
        //    else
        //    {
        //        UseSkill(selectedSkillCode);
        //        Owner.ResetSelectedSkill();
        //        ActionUseAfterSkill();
        //    }
            
        //}

        //private void ActionUseAfterSkill()
        //{
        //    var target = Owner.GetMainTarget();
        //    if (target == null) return;

        //    if (!Owner.IsFriend(target))
        //    {
        //        target = Owner.SearchTarget();

        //        if (target != null)
        //        {
        //            Owner.SetMainTarget(target);
        //            Owner.ChangeState((uint) STATE_ID_TRACK);
        //        }
        //        else
        //            Owner.ChangeState((uint) STATE_ID_IDLE);
                
        //    }
        //}
        //private void UseSkill(ushort skillCode)
        //{
        //    Logger.Instance.Log("Monster with ID:"+ Owner.GetObjectKey()+ " uses Skill: "+skillCode);
        //}
        //private void DoNormalAttack()
        //{
        //    var attackType = GlobalRand.Instance.Random(0, 100) % 2 + 1;
        //    uint actionDelay = 0;

        //    switch (attackType)
        //    {
        //        case 1:
        //            actionDelay = Owner.GetBaseInfo().AttackSpeed;
        //            break;
        //        case 2:
        //            actionDelay = Owner.GetBaseInfo().AttackSpeed2;
        //            break;
        //    }

        //    if (0 != Owner.GetPhysicalAttackSpeed())
        //    {
        //        actionDelay = (uint) (actionDelay / Owner.GetPhysicalAttackSpeed());
        //    }
        //    else
        //    {
        //        actionDelay = 1000;
        //        Logger.Instance.Log("Physical AttackSpeed of Object: " +Owner.GetObjectKey()+" is 0");
        //    }
            
        //    SetActionTimer(actionDelay);
            
        //    Owner.StopMoving();

        //    var target = Owner.GetMainTarget();
        //    ushort critRatioBonus = 0;
        //    bool isCrit = true;

        //    var damage = CharFormulas.CalcNormalDamage(Owner, target, (eATTACK_TYPE) Owner.GetBaseInfo().AttType,
        //        critRatioBonus, ref isCrit, 0);

        //    byte skillEffect = 0;
        //    if (isCrit)
        //        skillEffect |= 0x10;

        //    var resultDamage = target.Damaged(Owner, (eATTACK_TYPE) Owner.GetBaseInfo().AttType, damage);
            
        //    Owner.OnAttack(target,8100,resultDamage);

        //    var pos = Owner.GetPos();

        //    var attackResultInfo = new MonsterBasicAttackInfo(
        //        Owner.GetObjectKey(),
        //        target.GetObjectKey(),
        //        (byte) attackType,
        //        pos,
        //        resultDamage,
        //        (ushort) target.GetHP(),
        //        skillEffect
        //    );
        //    Owner.SendPacketAround(new S2CMonsterAttackCMD(attackResultInfo));

        //    AI_MSG_Attacked attackedMsg = new AI_MSG_Attacked(Owner.GetObjectKey(), resultDamage);
        //    target.SendAiMessage(attackedMsg);
        //}

        //protected override void OnMsgHelpRequest(AI_MSG msg) { }
        //protected override void OnMsgLetsGo(AI_MSG msg) { }
        //protected override void OnMsgEnemyFound(AI_MSG msg) { }
        //protected override void OnMsgForceAttack(AI_MSG msg)
        //{
        //    if (!(msg is AI_MSG_Force_Attack forceAttackMsg)) return;
        //    var target = Owner.GetMainTarget();
        //    if (target != null && target.GetObjectKey() == forceAttackMsg.TargetId)
        //        return;
            
        //    base.OnMsgForceAttack(msg);
        //}
    }
}
