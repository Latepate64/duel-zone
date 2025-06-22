using TriggeredAbilities;

namespace Cards.DM08
{
    sealed class ThrumissZephyrGuardian : Engine.Creature
    {
        public ThrumissZephyrGuardian() : base("Thrumiss, Zephyr Guardian", 6, 3000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverAnyOfYourCreaturesAttacksAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
