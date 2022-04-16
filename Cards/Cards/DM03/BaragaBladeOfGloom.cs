namespace Cards.Cards.DM03
{
    class BaragaBladeOfGloom : Creature
    {
        public BaragaBladeOfGloom() : base("Baraga, Blade of Gloom", 4, 4000, Engine.Race.DarkLord, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect());
        }
    }
}
