using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects;

public class SearchCardNoRevealEffect : SearchEffect
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

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.Cards;
    }
}
