using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CostModifying;

public class CardsCostLessEffect : ContinuousEffect, ICostModifyingEffect,
    IMinimumCostModifyingEffect
{
    private readonly ICardFilter filter;
    private readonly int reduction;
    private readonly int minimumCost;

    public CardsCostLessEffect(ICardFilter filter, int reduction, int minimumCost)
    {
        this.filter = filter;
        this.reduction = reduction;
        this.minimumCost = minimumCost;
    }

    protected CardsCostLessEffect(CardsCostLessEffect effect)
    {
        filter = effect.filter.Copy();
        reduction = effect.reduction;
        minimumCost = effect.minimumCost;
    }

    public override IContinuousEffect Copy()
    {
        return new CardsCostLessEffect(this);
    }

    public virtual int GetChange(ICard card, IGame game)
    {
        if (filter.Match(card)) return -reduction;
        return 0;
    }

    public virtual int GetMinimumCost(ICard card, IGame game)
    {
        if (filter.Match(card)) return minimumCost;
        return 0;
    }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj)) return false;
        if (obj is not CardsCostLessEffect effect) return false;
        if (!filter.Equals(effect.filter)) return false;
        if (reduction != effect.reduction) return false;
        if (minimumCost != effect.minimumCost) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), filter, reduction, minimumCost);
    }
}
