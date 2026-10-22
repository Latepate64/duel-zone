using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CostModifying;

public class YourCardsCostLessEffect : CardsCostLessEffect
{
    public YourCardsCostLessEffect(ICardFilter filter, int reduction, int minimumCost) : base(
        filter, reduction, minimumCost)
    {
    }

    protected YourCardsCostLessEffect(CardsCostLessEffect effect) : base(effect)
    {
    }

    public override int GetChange(ICard card, IGame game)
    {
        if (Applier.Equals(card.OwnerV2)) return base.GetChange(card, game);
        return 0;
    }

    public override int GetMinimumCost(ICard card, IGame game)
    {
        if (Applier.Equals(card.OwnerV2)) return base.GetMinimumCost(card, game);
        return 0;
    }

    public override IContinuousEffect Copy()
    {
        return new YourCardsCostLessEffect(this);
    }
}