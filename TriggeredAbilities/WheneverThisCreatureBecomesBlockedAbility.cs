using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverThisCreatureBecomesBlockedAbility : BecomeBlockedAbility
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

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card == Source;
    }
}
