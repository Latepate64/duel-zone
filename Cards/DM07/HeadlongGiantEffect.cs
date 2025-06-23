using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM07;

sealed class HeadlongGiantEffect : ContinuousEffect, ICannotAttackEffect
{
    public HeadlongGiantEffect()
    {
    }

    public HeadlongGiantEffect(HeadlongGiantEffect effect) : base(effect)
    {
    }

    public bool CannotAttack(ICreature creature, IGame game)
    {
        return IsSourceOfAbility(creature) && !Controller.Hand.HasCards;
    }

    public override IContinuousEffect Copy()
    {
        return new HeadlongGiantEffect(this);
    }

    public override string ToString()
    {
        return "This creature can't attack if you have no cards in your hand.";
    }
}
