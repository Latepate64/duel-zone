namespace Cards.Cards.DM10
{
    public class TorpedoCluster : Creature
    {
        public TorpedoCluster() : base("Torpedo Cluster", 3, 3000, Engine.Race.CyberCluster, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardFromYourManaZoneToYourHandEffect());
        }
    }
}
