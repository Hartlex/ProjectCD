using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class ChaosStatus : AbilityStatus
    {
        public override void Start()
        {
            if (GetOwner() == null) return;
            if (Attacker == null) return;
            var msg = new AIMsgRunAway(DateTime.Now.Ticks, Attacker.GetKey(), GetApplicationTime());
            GetOwner()!.OnAiMessage(msg);
        }

        public override void Execute()
        {
            
        }
    }
}
