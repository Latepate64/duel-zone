using Cards.TriggeredAbilities;
using Effects.Continuous;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM12
{
    class ExtremeCrawler : Creature
    {
        public ExtremeCrawler() : base("Extreme Crawler", 5, 7000, Race.EarthEater, Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ExtremeCrawlerEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }

    class ExtremeCrawlerEffect : OneShotEffects.BounceAreaOfEffect
    {
        public ExtremeCrawlerEffect() : base()
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

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(Ability.Controller.Id, Ability.Source.Id);
        }
    }
}
