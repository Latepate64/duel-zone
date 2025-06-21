using Interfaces;

namespace Engine.Abilities;

public class SilentSkillAbility : ActivatedAbility, ISilentSkillAbility
{
    public SilentSkillAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public SilentSkillAbility(SilentSkillAbility ability) : base(ability)
    {
    }

    public override ISilentSkillAbility Copy()
    {
        return new SilentSkillAbility(this);
    }

    public override string ToString()
    {
        return $"Silent skill: {OneShotEffect}";
    }
}
