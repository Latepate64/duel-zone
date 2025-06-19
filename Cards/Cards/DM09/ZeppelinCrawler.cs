using Abilities.Triggered;
using Cards.ContinuousEffects;
using Effects.Continuous;
using Engine;

namespace Cards.Cards.DM09
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
