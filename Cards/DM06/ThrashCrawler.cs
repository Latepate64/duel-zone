using Abilities.Static;
using ContinuousEffects.CannotAttack;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class ThrashCrawler : Creature
    {
        public ThrashCrawler() : base("Thrash Crawler", 4, 5000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
