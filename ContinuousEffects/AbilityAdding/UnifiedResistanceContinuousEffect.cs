using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.AbilityAdding;

public sealed class UnifiedResistanceContinuousEffect : AbilityAddingEffect, IExpirable
{
    private readonly Guid _player;
    private readonly ICard[] _cards;

    public UnifiedResistanceContinuousEffect(UnifiedResistanceContinuousEffect effect) : base(effect)
    {
        _player = effect._player;
        _cards = effect._cards;
    }

    public UnifiedResistanceContinuousEffect(Guid player, params ICard[] cards) : base(
        new BlockerAbility())
    {
        _player = player;
        _cards = cards;
    }

    public override IContinuousEffect Copy()
    {
        return new UnifiedResistanceContinuousEffect(this);
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.StartOfTurn
        //     && phase.Turn.ActivePlayer.Id == _player;
    }

    public override string ToString()
    {
        return $"Until the start of your next turn, {_cards} have \"Blocker\".";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
