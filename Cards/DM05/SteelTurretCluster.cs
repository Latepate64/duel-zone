using CardFilters;
using ContinuousEffects;
using Interfaces;

namespace Cards.DM05;

sealed class SteelTurretCluster : Creature
{
    public SteelTurretCluster() : base("Steel-Turret Cluster", 5, 3000, Race.CyberCluster, Civilization.Water)
    {
        AddStaticAbilities(
            new ThisCreatureCannotBeAttackedEffect(
                new CivilizationCreatureFilter(
                    Civilization.Fire,
                    Civilization.Nature)));
    }
}
