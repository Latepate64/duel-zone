using Effects.OneShot;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects;

public class SearchSpellEffect : SearchEffect
{
    public SearchSpellEffect() : base(true)
    {
    }

    public SearchSpellEffect(SearchEffect effect) : base(effect)
    {
    }

    public SearchSpellEffect(bool reveal, int maximum = 1) : base(reveal, maximum)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SearchSpellEffect(this);
    }

    public override string ToString()
    {
        return "Search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.Spells;
    }
}
