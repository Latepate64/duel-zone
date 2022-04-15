using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class SteelTurretCluster : Creature
    {
        public SteelTurretCluster() : base("Steel-Turret Cluster", 5, 3000, Engine.Subtype.CyberCluster, Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(Civilization.Fire, Civilization.Nature));
        }
    }
}
