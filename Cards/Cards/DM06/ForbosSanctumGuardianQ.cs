namespace Cards.Cards.DM06
{
    class ForbosSanctumGuardianQ : Creature
    {
        public ForbosSanctumGuardianQ() : base("Forbos, Sanctum Guardian Q", 6, 4000, Engine.Race.Survivor, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSpellEffect()));
        }
    }
}
