using TriggeredAbilities;

namespace Cards.DM10
{
    class TorpedoCluster : Engine.Creature
    {
        public TorpedoCluster() : base("Torpedo Cluster", 3, 3000, Interfaces.Race.CyberCluster, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}
