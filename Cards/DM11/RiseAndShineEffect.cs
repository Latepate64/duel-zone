using Engine;
using Engine.Abilities;
using Interfaces;
using System.Linq;

namespace Cards.DM11;

public class RiseAndShineEffect : OneShotEffect
{
    public RiseAndShineEffect()
    {
    }

    public RiseAndShineEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = Controller.RevealTopCardsOfDeck(4, game);
        var blockers = cards.OfType<Creature>().Where(x => x.IsBlocker);
        var chosen = Controller.ChooseCard(blockers, ToString());
        game.Move(Ability, ZoneType.Deck, ZoneType.Hand, chosen);
        Controller.PutOnTheBottomOfDeckInAnyOrder([.. cards.Where(x => x != chosen)]);
    }

    public override IOneShotEffect Copy()
    {
        return new RiseAndShineEffect(this);
    }

    public override string ToString()
    {
        return "Reveal the top 4 cards of your deck. Put one of them that has \"blocker\" into your hand, and put the rest on the bottom of your deck in any order.";
    }
}
