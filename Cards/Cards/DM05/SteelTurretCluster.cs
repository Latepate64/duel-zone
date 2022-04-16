using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class SteelTurretCluster : Creature
    {
        public SteelTurretCluster() : base("Steel-Turret Cluster", 5, 3000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Engine.Civilization.Fire, Engine.Civilization.Nature));
        }
    }
}
