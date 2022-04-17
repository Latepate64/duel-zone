using Engine;

namespace Cards.Cards.DM09
{
    class ZeppelinCrawler : Creature
    {
        public ZeppelinCrawler() : base("Zeppelin Crawler", 5, 4000, Race.EarthEater, Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
            AddTriggeredAbility(new TriggeredAbilities.WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
