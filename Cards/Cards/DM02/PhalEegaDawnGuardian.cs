namespace Cards.Cards.DM02
{
    class PhalEegaDawnGuardian : Creature
    {
        public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, 4000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect()));
        }
    }
}
