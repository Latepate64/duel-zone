using Engine;
using Engine.Abilities;

namespace Abilities.Triggered;

public class WhenThisCreatureIsDestroyedAbility : DestroyedAbility
{
    public WhenThisCreatureIsDestroyedAbility(WhenThisCreatureIsDestroyedAbility ability) : base(ability)
    {
    }

    public WhenThisCreatureIsDestroyedAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public override IAbility Copy()
    {
        return new WhenThisCreatureIsDestroyedAbility(this);
    }

    public override string ToString()
    {
        return $"When this creature is destroyed, {GetEffectText()}";
    }

    protected override bool TriggersFrom(Creature card, IGame game)
    {
        return card == Source;
    }
}
