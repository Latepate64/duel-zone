using Common;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class ExtremeCrawler : Creature
    {
        public ExtremeCrawler() : base("Extreme Crawler", 5, 7000, Subtype.EarthEater, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new ExtremeCrawlerEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class ExtremeCrawlerEffect : OneShotEffects.BounceAreaOfEffect
    {
        public ExtremeCrawlerEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ExtremeCrawlerEffect();
        }

        public override string ToString()
        {
            return "Return all your other creatures from the battle zone to your hand.";
        }
    }
}
