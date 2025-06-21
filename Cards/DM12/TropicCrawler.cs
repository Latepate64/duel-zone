using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM12
{
    class TropicCrawler : Creature
    {
        public TropicCrawler() : base("Tropic Crawler", 4, 3000, Race.EarthEater, Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new TropicCrawlerEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }

    class TropicCrawlerEffect : CardMovingChoiceEffect<Creature>
    {
        public TropicCrawlerEffect() : base(1, 1, false, ZoneType.BattleZone, ZoneType.Hand)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TropicCrawlerEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of his creatures in the battle zone, and returns it to his hand.";
        }

        protected override IEnumerable<Creature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(GetOpponent(game).Id);
        }
    }
}
