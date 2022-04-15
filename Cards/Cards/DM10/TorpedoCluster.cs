namespace Cards.Cards.DM10
{
    class TorpedoCluster : Creature
    {
        public TorpedoCluster() : base("Torpedo Cluster", 3, 3000, Engine.Subtype.CyberCluster, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnCardsFromYourManaZoneToYourHandEffect(1));
        }
    }
}
