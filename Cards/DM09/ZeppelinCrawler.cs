using TriggeredAbilities;
using ContinuousEffects;
using Engine;

namespace Cards.DM09
{
    class ZeppelinCrawler : Creature
    {
        public ZeppelinCrawler() : base("Zeppelin Crawler", 5, 4000, Race.EarthEater, Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
