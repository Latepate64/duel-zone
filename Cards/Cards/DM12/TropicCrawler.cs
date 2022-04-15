using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM12
{
    class TropicCrawler : Creature
    {
        public TropicCrawler() : base("Tropic Crawler", 4, 3000, Engine.Subtype.EarthEater, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new TropicCrawlerEffect()));
            AddThisCreatureCannotAttackAbility();
        }
    }

    class TropicCrawlerEffect : OneShotEffects.CardMovingChoiceEffect
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

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.GetOpponent(game).Id);
        }
    }
}
