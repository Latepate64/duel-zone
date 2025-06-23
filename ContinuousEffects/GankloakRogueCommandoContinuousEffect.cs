using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class GankloakRogueCommandoContinuousEffect(params ICard[] cards) : AddAbilitiesUntilEndOfTurnEffect(
    new StaticAbility(new DoubleBreakerEffect()), cards)
{
    public override IContinuousEffect Copy()
    {
        return new GankloakRogueCommandoContinuousEffect();
    }

    public override string ToString()
    {
        return "Each of your fire creatures in the battle zone gets \"double breaker\" until the end of the turn.";
    }
}
