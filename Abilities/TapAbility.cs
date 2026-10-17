using Interfaces;

namespace Abilities;

public sealed class TapAbility : ActivatedAbility, ITapAbility
{
    public TapAbility(IOneShotEffect effect) : base(effect)
    {
    }

    private TapAbility(TapAbility ability) : base(ability)
    {
    }

    public override ITapAbility Copy()
    {
        return new TapAbility(this);
    }
}
