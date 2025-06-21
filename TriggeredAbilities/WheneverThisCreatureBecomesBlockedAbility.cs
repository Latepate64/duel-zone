using Engine;
using Engine.Abilities;

namespace TriggeredAbilities;

public class WheneverThisCreatureBecomesBlockedAbility : BecomeBlockedAbility
{
    public WheneverThisCreatureBecomesBlockedAbility(IOneShotEffect effect) : base(effect)
    { 
    }

    public WheneverThisCreatureBecomesBlockedAbility(WheneverThisCreatureBecomesBlockedAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new WheneverThisCreatureBecomesBlockedAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever this creature becomes blocked, {GetEffectText()}";
    }

    protected override bool TriggersFrom(Creature card, IGame game)
    {
        return card == Source;
    }
}
