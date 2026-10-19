using Interfaces;

namespace ContinuousEffects.AbilityAdding;

public abstract class AddAbilitiesUntilEndOfTurnEffect : AbilityAddingEffect
{
    private readonly ICard[] _cards;

    protected AddAbilitiesUntilEndOfTurnEffect(AddAbilitiesUntilEndOfTurnEffect effect) : base(effect)
    {
        _cards = effect._cards;
    }

    protected AddAbilitiesUntilEndOfTurnEffect(IAbility[] abilities, params ICreature[] creatures) : base(abilities)
    {
        _cards = creatures;
    }

    protected AddAbilitiesUntilEndOfTurnEffect(ICard card, params IAbility[] abilities) : base(abilities)
    {
        _cards = [card];
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return _cards;
    }
}
