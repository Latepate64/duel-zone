using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    sealed class BallusDogfightEnforcerQ : Creature
    {
        public BallusDogfightEnforcerQ() : base("Ballus, Dogfight Enforcer Q", 5, 3000, [Interfaces.Race.Survivor, Interfaces.Race.Berserker], Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new SurvivorEffect(new AtTheEndOfYourTurnAbility(
                new OneShotEffects.UntapThisCreatureEffect())));
        }
    }
}
