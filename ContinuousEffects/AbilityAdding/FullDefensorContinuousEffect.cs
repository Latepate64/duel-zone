using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

/// <summary>
/// Until the start of your next turn, each of your creatures in the battle zone
/// has "Blocker".
/// </summary>
public sealed class FullDefensorContinuousEffect : AbilityAddingEffect, IExpirable
{
    private readonly ICard[] _cards;

    public FullDefensorContinuousEffect(FullDefensorContinuousEffect effect) : base(effect)
    {
        _cards = effect._cards;
    }

    public FullDefensorContinuousEffect(params ICard[] cards) : base(
        new BlockerAbility())
    {
        _cards = cards;
    }

    public override IContinuousEffect Copy()
    {
        return new FullDefensorContinuousEffect(this);
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
