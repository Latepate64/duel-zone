using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    class MistRiasSonicGuardian : Engine.Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, 2000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new YouMayDrawCardEffect()));
        }
    }
}
