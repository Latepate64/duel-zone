using Abilities.Triggered;
using Cards.OneShotEffects;
using Abilities.Triggered;

namespace Cards.Cards.DM04
{
    class MistRiasSonicGuardian : Engine.Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, 2000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new YouMayDrawCardEffect()));
        }
    }
}
