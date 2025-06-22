using ContinuousEffects;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM09;

public class VenomWormContinuousEffect : AddAbilitiesUntilEndOfTurnEffect
{
    private readonly Race _race;

    public VenomWormContinuousEffect(VenomWormContinuousEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public VenomWormContinuousEffect(Race race, params ICard[] cards) : base(
        new StaticAbility(new ThisCreatureHasSlayerEffect()), cards)
    {
        _race = race;
    }

    public override IContinuousEffect Copy()
    {
        return new VenomWormContinuousEffect(this);
    }

    public override string ToString()
    {
        return $"{_race} have \"slayer\" until the end of the turn.";
    }
}
