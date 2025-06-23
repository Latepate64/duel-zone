using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    sealed class MistRiasSonicGuardian : Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, 2000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new YouMayDrawCardEffect()));
        }
    }
}
