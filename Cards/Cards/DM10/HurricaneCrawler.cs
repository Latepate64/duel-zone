using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class HurricaneCrawler : Creature
    {
        public HurricaneCrawler() : base("Hurricane Crawler", 5, 4000, Engine.Subtype.EarthEater, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new HurricaneCrawlerEffect());
        }
    }

    class HurricaneCrawlerEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var hand = source.GetController(game).Hand.Cards;
            var amount = hand.Count;
            game.Move(ZoneType.Hand, ZoneType.ManaZone, hand.ToArray());
            return new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(amount).Apply(game, source);
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
