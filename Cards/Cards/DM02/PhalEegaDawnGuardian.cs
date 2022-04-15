namespace Cards.Cards.DM02
{
    class PhalEegaDawnGuardian : Creature
    {
        public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, 4000, Engine.Subtype.Guardian, Common.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect());
        }
    }
}
