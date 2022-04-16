namespace Cards.Cards.DM12
{
    class PharziTheOracle : Creature
    {
        public PharziTheOracle() : base("Pharzi, the Oracle", 2, 1000, Engine.Race.LightBringer, Engine.Civilization.Light)
        {
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect());
        }
    }
}
