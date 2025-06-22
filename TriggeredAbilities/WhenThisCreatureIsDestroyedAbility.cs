using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public sealed class WhenThisCreatureIsDestroyedAbility : DestroyedAbility
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

    protected override bool TriggersFrom(ICreature card, IGame game)
    {
        return card == Source;
    }
}
