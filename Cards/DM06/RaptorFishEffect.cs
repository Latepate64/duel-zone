using Engine.Abilities;
using Interfaces;

namespace Cards.DM06;

public class RaptorFishEffect : OneShotEffect
{
    public RaptorFishEffect()
    {
    }

    public RaptorFishEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var amount = Controller.Hand.Size;
        game.Move(Ability, ZoneType.Hand, ZoneType.Deck, [.. Controller.Hand.Cards]);
        Controller.ShuffleOwnDeck(game);
        Controller.DrawCards(amount, game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new RaptorFishEffect(this);
    }

    public override string ToString()
    {
        return "Count the cards in your hand, shuffle those cards into your deck, then draw that many cards.";
    }
}
