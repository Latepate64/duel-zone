using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class HurricaneCrawler : Creature
    {
        public HurricaneCrawler() : base("Hurricane Crawler", 5, 4000, Race.EarthEater, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new HurricaneCrawlerEffect());
        }
    }

    class HurricaneCrawlerEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var player = source.GetController(game);
            var hand = player.Hand.Cards;
            var amount = hand.Count;
            game.Move(source, ZoneType.Hand, ZoneType.ManaZone, hand.ToArray());
            var cards = player.ChooseCards(player.ManaZone.Cards, amount, amount, ToString());
            game.Move(source, ZoneType.ManaZone, ZoneType.Hand, cards.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new HurricaneCrawlerEffect();
        }

        public override string ToString()
        {
            return "Put all the cards from your hand into your mana zone. Then put that many cards from your mana zone into your hand.";
        }
    }
}
