using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class EssenceElfEffect : ContinuousEffect, ICostModifyingEffect, IMinimumCostModifyingEffect
{
    public EssenceElfEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new EssenceElfEffect();
    }

    public int GetChange(ICard card, IGame game)
    {
        return card.Owner == Controller && card is ISpell ? -1 : 0;
    }

    public int GetMinimumCost(ICard card, IGame game)
    {
        return card.Owner == Controller && card is ISpell ? 1 : 0;
    }

    public override string ToString()
    {
        return "Your spells each cost 1 less to cast. They can't cost less than 1.";
    }
}
