using Common;

namespace Cards.Cards.DM05
{
    class BallusDogfightEnforcerQ : Creature
    {
        public BallusDogfightEnforcerQ() : base("Ballus, Dogfight Enforcer Q", 5, 3000, Civilization.Light)
        {
            AddSubtypes(Subtype.Survivor, Subtype.Berserker);
            AddAbilities(new StaticAbilities.SurvivorAbility(new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.UntapThisCreatureEffect())));
        }
    }
}
