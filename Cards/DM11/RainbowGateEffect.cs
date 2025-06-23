using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Cards.DM11;

public sealed class RainbowGateEffect : SearchEffect
{
    public RainbowGateEffect() : base(true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new RainbowGateEffect();
    }

    public override string ToString()
    {
        return "Search your deck. You may take a multi-colored creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.Creatures.Where(x => x.IsMultiColored);
    }
}
