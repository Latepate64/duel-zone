using Common;

namespace Cards.Cards.DM05
{
    class BallusDogfightEnforcerQ : Creature
    {
        public BallusDogfightEnforcerQ() : base("Ballus, Dogfight Enforcer Q", 5, 3000, Subtype.Survivor, Subtype.Berserker, Civilization.Light)
        {
            AddSurvivorAbility(new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.UntapThisCreatureEffect()));
        }
    }
}
