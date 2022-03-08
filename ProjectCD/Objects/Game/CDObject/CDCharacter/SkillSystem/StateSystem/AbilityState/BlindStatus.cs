using SunStructs.ServerInfos.General.Object.AI;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;
using static SunStructs.Definitions.AttrType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class BlindStatus :AbilityStatus
    {
        private int _prevSightRange;
        public override void Execute() { }
        public override void Start()
        {
            _prevSightRange = GetOwner()!.GetSightRange() * 10;
            GetOwner()!.SetAttr(ATTR_SIGHT_RANGE, BASE, 10);

            var msg = new AIMsgBlind(GetApplicationTime());
            GetOwner()!.OnAiMessage(msg);
        }

        public override void End()
        {
            GetOwner()!.SetAttr(ATTR_SIGHT_RANGE, BASE, _prevSightRange);
            base.End();
        }
    }
}
