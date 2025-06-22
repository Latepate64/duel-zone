using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WheneverAnotherCreatureIsDestroyedAbility : DestroyedAbility
{
    public WheneverAnotherCreatureIsDestroyedAbility(IOneShotEffect effect) : base(effect) { }

    public WheneverAnotherCreatureIsDestroyedAbility(WheneverAnotherCreatureIsDestroyedAbility ability) : base(ability)
    {
    }

    public override IAbility Copy()
    {
        return new WheneverAnotherCreatureIsDestroyedAbility(this);
    }

    public override string ToString()
    {
        return $"Whenever another creature is destroyed, {GetEffectText()}";
    }

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card != Source;
    }
}
