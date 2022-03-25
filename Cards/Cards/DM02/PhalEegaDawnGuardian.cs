namespace Cards.Cards.DM02
{
    class PhalEegaDawnGuardian : Creature
    {
        public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, 4000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, you may return a spell from your graveyard to your hand.
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.SalvageEffect(new CardFilters.OwnersGraveyardSpellFilter(), 0, 1, true)));
        }
    }
}
