using GameEvents;
using GameEvents.Steps;
using Interfaces;

namespace ContinuousEffects;

public abstract class AddAbilitiesUntilEndOfTurnEffect : AbilityAddingEffect, IExpirable
{
    private readonly ICard[] _cards;

    protected AddAbilitiesUntilEndOfTurnEffect(AddAbilitiesUntilEndOfTurnEffect effect) : base(effect)
    {
        _cards = effect._cards;
    }

    protected AddAbilitiesUntilEndOfTurnEffect(IAbility ability, params ICard[] cards) : base([ability])
    {
        _cards = cards;
    }

    protected AddAbilitiesUntilEndOfTurnEffect(IAbility ability1, IAbility ability2, params ICard[] cards) : base([ability1, ability2])
    {
        _cards = cards;
    }

    protected AddAbilitiesUntilEndOfTurnEffect(ICard card, params IAbility[] abilities) : base(abilities)
    {
        _cards = [card];
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
