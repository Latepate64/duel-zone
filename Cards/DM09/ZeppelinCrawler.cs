using TriggeredAbilities;
using Interfaces;
using StaticAbilities;
using ContinuousEffects.CannotAttack;

namespace Cards.DM09
{
    sealed class ZeppelinCrawler : Creature
    {
        public ZeppelinCrawler() : base("Zeppelin Crawler", 5, 4000, Race.EarthEater, Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new OneShotEffects.LookAtTheTopCardsOfYourDeckTakeOnePutRestOnBottomEffect()));
        }
    }
}
