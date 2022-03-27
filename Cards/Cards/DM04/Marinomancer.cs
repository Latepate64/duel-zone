using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class Marinomancer : Creature
    {
        public Marinomancer() : base("Marinomancer", 5, 2000, Subtype.CyberLord, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new MarinomancerEffect()));
        }
    }

    class MarinomancerEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            var cards = player.RevealTopCardsOfDeck(3, game);
            var toHand = cards.Where(x => x.Civilizations.Contains(Civilization.Light) || x.Civilizations.Contains(Civilization.Darkness));
            game.Move(ZoneType.Deck, ZoneType.Hand, toHand.ToArray());
            game.Move(ZoneType.Deck, ZoneType.Graveyard, cards.Except(toHand).ToArray());
            player.Unreveal(cards);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new MarinomancerEffect();
        }

        public override string ToString()
        {
            return "You may reveal the top 3 cards of your deck. Put all light cards and all darkness cards from the revealed cards into your hand, and put the rest into your graveyard.";
        }
    }
}
