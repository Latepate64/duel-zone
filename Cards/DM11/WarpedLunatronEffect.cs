using ContinuousEffects;
using Interfaces.ContinuousEffects;

namespace Cards.DM11;

public sealed class WarpedLunatronEffect : ContinuousEffect, ICreaturesDoNotUntapAtTheStartOfEachPlayersTurn
{
    public WarpedLunatronEffect()
    {
    }

    public WarpedLunatronEffect(IContinuousEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new WarpedLunatronEffect(this);
    }

    public override string ToString()
    {
        return "Creatures in the battle zone don't untap at the start of each player's turn.";
    }
}
