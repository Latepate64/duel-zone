using StaticAbilities;
using ContinuousEffects.CannotAttack;
using ContinuousEffects;
using CardFilters;

namespace Cards.DM07
{
    sealed class TitaniumCluster : Creature
    {
        public TitaniumCluster() : base("Titanium Cluster", 4, 4000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect(new CreatureFilter()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}
