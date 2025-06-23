using Engine.Abilities;
using System.Linq;
using Interfaces;

namespace OneShotEffects;

public sealed class MarinomancerEffect : OneShotEffect
{
    public MarinomancerEffect()
    {
    }

    public MarinomancerEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var cards = Controller.RevealTopCardsOfDeck(3, game);
        var toHand = cards.Where(x => x.HasCivilization(Civilization.Light) || x.HasCivilization(Civilization.Darkness));
        game.Move(Ability, ZoneType.Deck, ZoneType.Hand, [.. toHand]);
        game.Move(Ability, ZoneType.Deck, ZoneType.Graveyard, [.. cards.Except(toHand)]);
        Controller.Unreveal([.. cards]);
    }

    public override IOneShotEffect Copy()
    {
        return new MarinomancerEffect(this);
    }

    public override string ToString()
    {
        return "You may reveal the top 3 cards of your deck. Put all light cards and all darkness cards from the revealed cards into your hand, and put the rest into your graveyard.";
    }
}
