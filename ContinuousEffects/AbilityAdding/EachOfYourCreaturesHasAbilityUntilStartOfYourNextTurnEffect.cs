using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect
    : AbilityAddingEffect
{
    private readonly ICard[] _cards;

    public EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect(
        IStaticAbilityFactory factory, params ICard[] cards) : base(factory.Create())
    {
        _cards = cards;
    }

    private EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect(
        EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect effect) : base(effect)
    {
        _cards = effect._cards;
    }

    public override IContinuousEffect Copy()
    {
        return new EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect(this);
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
