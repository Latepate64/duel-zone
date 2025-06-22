using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SearchCardNoRevealEffect : SearchEffect
{
    public SearchCardNoRevealEffect() : base(false)
    {
    }

    public SearchCardNoRevealEffect(SearchEffect effect) : base(effect)
    {
    }

    public SearchCardNoRevealEffect(bool reveal, int maximum = 1) : base(reveal, maximum)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SearchCardNoRevealEffect(this);
    }

    public override string ToString()
    {
        return "Search your deck. You may take a card from your deck and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.Cards;
    }
}
