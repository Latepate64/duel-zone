using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CostModifying;

public sealed class CardsCostMoreEffect : ContinuousEffect, ICostModifyingEffect
{
    private readonly ICardFilter filter;
    private readonly int increase;

    public CardsCostMoreEffect(ICardFilter filter, int increase)
    {
        this.filter = filter;
        this.increase = increase;
    }

    private CardsCostMoreEffect(CardsCostMoreEffect effect)
    {
        filter = effect.filter.Copy();
        increase = effect.increase;
    }

    public override IContinuousEffect Copy()
    {
        return new CardsCostMoreEffect(this);
    }

    public int GetChange(ICard card, IGame game)
    {
        if (filter.Match(card)) return increase;
        return 0;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CardsCostMoreEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        if (increase != effect.increase) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), filter, increase);
    }
}
