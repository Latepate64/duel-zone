using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class EachOfYourCreaturesHasAbilityUntilStartOfYourNextTurnEffect
    : AbilityAddingEffect, IExpirable
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

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
        //     && phase.Turn.ActivePlayer.Id == _player;
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
