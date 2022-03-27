using Common;

namespace Cards.Cards.DM05
{
    class SteelTurretCluster : Creature
    {
        public SteelTurretCluster() : base("Steel-Turret Cluster", 5, 3000, Subtype.CyberCluster, Civilization.Water)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeAttackedByCivilizationCreaturesAbility(Civilization.Fire, Civilization.Nature));
        }
    }
}
