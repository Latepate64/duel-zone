using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class BallusDogfightEnforcerQ : Engine.Creature
    {
        public BallusDogfightEnforcerQ() : base("Ballus, Dogfight Enforcer Q", 5, 3000, [Engine.Race.Survivor, Engine.Race.Berserker], Engine.Civilization.Light)
        {
            AddStaticAbilities(new SurvivorEffect(new TriggeredAbilities.AtTheEndOfYourTurnAbility(
                new OneShotEffects.UntapThisCreatureEffect())));
        }
    }
}
