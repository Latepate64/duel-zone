using TriggeredAbilities;

namespace Cards.Cards.DM10
{
    class TorpedoCluster : Engine.Creature
    {
        public TorpedoCluster() : base("Torpedo Cluster", 3, 3000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect()));
        }
    }
}
