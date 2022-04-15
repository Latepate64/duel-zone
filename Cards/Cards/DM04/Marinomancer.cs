using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class Marinomancer : Creature
    {
        public Marinomancer() : base("Marinomancer", 5, 2000, Engine.Subtype.CyberLord, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new MarinomancerEffect());
        }
    }

    class MarinomancerEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetController(game).RevealTopCardsOfDeck(3, game);
            var toHand = cards.Where(x => x.HasCivilization(Engine.Civilization.Light) || x.HasCivilization(Engine.Civilization.Darkness));
            game.Move(ZoneType.Deck, ZoneType.Hand, toHand.ToArray());
            game.Move(ZoneType.Deck, ZoneType.Graveyard, cards.Except(toHand).ToArray());
            source.GetController(game).Unreveal(cards);
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
