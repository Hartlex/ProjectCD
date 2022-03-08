using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.NonTargetAbilities;

internal class AuroraAbility : BuffStatusAbility
{
    public override bool IsValidState()
    {
        switch (GetCharStateType())
        {
            case CharStateType.CHAR_STATE_SLOW_AURORA:
            case CharStateType.CHAR_STATE_BOOST_AURORA:
            case CharStateType.CHAR_STATE_CONCENTRATION_AURORA:
            case CharStateType.CHAR_STATE_MISCHANCE_AURORA:
            case CharStateType.CHAR_STATE_DECLINE_AURORA:
            case CharStateType.CHAR_STATE_RECOVERY_AURORA:
            case CharStateType.CHAR_STATE_IGNORE_AURORA:
            case CharStateType.CHAR_STATE_IGNORE_RESERVEHP6:
                return true;
        }

        return false;
    }

    public override AbilityType GetAbilityType()
    {
        return AbilityType.ABILITY_TYPE_ACTIVE_AND_EFFECT;
    }

    public override bool ExecuteEffect(out SkillResultEffect? result)
    {
        var periodicEffectAbility = new PeriodicEffectAbility();
        periodicEffectAbility.Init(GetSkill(),GetBaseAbilityInfo());
        return periodicEffectAbility.ExecuteEffect(out result);
    }

    public override bool Execute(Character? target, out SkillResultAbility? result)
    {
        result = null;
        var statusManager = GetAttacker()?.GetStatusManager();
        if (statusManager == null) return false;

        var auroraStatus = statusManager.FindAuroraStatus();
        if (auroraStatus != null)
        {
            statusManager.Remove(auroraStatus.GetStateType());
        }
        return base.Execute(target, out result);
    }
}