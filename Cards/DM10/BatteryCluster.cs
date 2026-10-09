using Abilities.Static;
using ContinuousEffects.CannotAttack;

namespace Cards.DM10
{
    sealed class BatteryCluster : Creature
    {
        public BatteryCluster() : base("Battery Cluster", 2, 3000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
