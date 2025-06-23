using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class TerradragonCusdalfEffect : ContinuousEffect, IPlayerCannotUntapCardsInManaZoneAtStartOfTurn
{
    public TerradragonCusdalfEffect()
    {
    }

    public TerradragonCusdalfEffect(IContinuousEffect effect) : base(effect)
    {
    }

    public override IContinuousEffect Copy()
    {
        return new TerradragonCusdalfEffect(this);
    }

    public bool PlayerCannotUntapCardsInManaZoneAtStartOfTurn(IPlayer player)
    {
        return player == Controller;
    }

    public override string ToString()
    {
        return "You can't untap the cards in your mana zone at the start of each of your turns.";
    }
}
