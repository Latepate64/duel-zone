using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM06
{
    sealed class HazardCrawler : Creature
    {
        public HazardCrawler() : base("Hazard Crawler", 5, 6000, Interfaces.Race.EarthEater, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
