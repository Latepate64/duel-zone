using ContinuousEffects;

namespace Cards.DM05
{
    sealed class SteelTurretCluster : Engine.Creature
    {
        public SteelTurretCluster() : base("Steel-Turret Cluster", 5, 3000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Interfaces.Civilization.Fire, Interfaces.Civilization.Nature));
        }
    }
}
