using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects;

public class SearchCreatureEffect : SearchEffect
{
    public SearchCreatureEffect() : base(true)
    {
    }

    public SearchCreatureEffect(SearchEffect effect) : base(effect)
    {
    }

    public SearchCreatureEffect(bool reveal, int maximum = 1) : base(reveal, maximum)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SearchCreatureEffect(this);
    }

    public override string ToString()
    {
        return "Search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.Creatures;
    }
}
