using Abilities.Triggered;

namespace Cards.Cards.DM08
{
    class ThrumissZephyrGuardian : Engine.Creature
    {
        public ThrumissZephyrGuardian() : base("Thrumiss, Zephyr Guardian", 6, 3000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverAnyOfYourCreaturesAttacksAbility(new OneShotEffects.YouMayChooseOneOfYourOpponentsCreaturesAndTapItEffect()));
        }
    }
}
