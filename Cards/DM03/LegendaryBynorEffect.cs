using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public sealed class LegendaryBynorEffect : ContinuousEffect, IUnblockableEffect
{
    public LegendaryBynorEffect() : base()
    {
    }

    public LegendaryBynorEffect(LegendaryBynorEffect effect) : base(effect)
    {
    }

    public bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game)
    {
        return !IsSourceOfAbility(attacker) && attacker.HasCivilization(Civilization.Water);
    }

    public override IContinuousEffect Copy()
    {
        return new LegendaryBynorEffect(this);
    }

    public override string ToString()
    {
        return "Your other water creatures in the battle zone can't be blocked.";
    }
}
