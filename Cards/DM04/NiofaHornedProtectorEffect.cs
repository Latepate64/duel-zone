using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM04;

public class NiofaHornedProtectorEffect : SearchEffect
{
    public NiofaHornedProtectorEffect() : base(true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new NiofaHornedProtectorEffect();
    }

    public override string ToString()
    {
        return "When you put this creature into the battle zone, search your deck. You may take a nature creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.Deck.GetCreatures(Civilization.Nature);
    }
}
