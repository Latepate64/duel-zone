using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class Marinomancer : Creature
    {
        public Marinomancer() : base("Marinomancer", 5, 2000, Race.CyberLord, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new MarinomancerEffect());
        }
    }

    class MarinomancerEffect : OneShotEffect
    {
        public MarinomancerEffect()
        {
        }

        public MarinomancerEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var cards = GetController(game).RevealTopCardsOfDeck(3, game);
            var toHand = cards.Where(x => x.HasCivilization(Civilization.Light) || x.HasCivilization(Civilization.Darkness));
            game.Move(GetSourceAbility(game), ZoneType.Deck, ZoneType.Hand, toHand.ToArray());
            game.Move(GetSourceAbility(game), ZoneType.Deck, ZoneType.Graveyard, cards.Except(toHand).ToArray());
            GetController(game).Unreveal(cards);
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
}
