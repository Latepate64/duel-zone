namespace Cards.Cards.DM08
{
    class ThrumissZephyrGuardian : Creature
    {
        public ThrumissZephyrGuardian() : base("Thrumiss, Zephyr Guardian", 6, 3000, Engine.Subtype.Guardian, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnyOfYourCreaturesAttacksAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
