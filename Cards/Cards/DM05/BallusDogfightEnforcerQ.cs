namespace Cards.Cards.DM05
{
    class BallusDogfightEnforcerQ : Creature
    {
        public BallusDogfightEnforcerQ() : base("Ballus, Dogfight Enforcer Q", 5, 3000, Engine.Race.Survivor, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddSurvivorAbility(new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.UntapThisCreatureEffect()));
        }
    }
}
