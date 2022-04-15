namespace Cards.Cards.DM01
{
    class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnUpToCreaturesFromYourGraveyardToYourHandEffect(2));
        }
    }
}
