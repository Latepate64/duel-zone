using ContinuousEffects;
using Engine;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM02;

public sealed class ElfXEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
{
    public ElfXEffect() : base() { }

    public override IContinuousEffect Copy()
    {
        return new ElfXEffect();
    }

    public int GetChange(ICard card, IGame game)
    {
        return card.Owner == Controller && card is Creature ? -1 : 0;
    }

    public int GetMinimumCost(ICard card, IGame game)
    {
        return card.Owner == Controller && card is Creature ? 1 : 0;
    }

    public override string ToString()
    {
        return "Your creatures each cost 1 less to summon. They can't cost less than 1.";
    }
}
