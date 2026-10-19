using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM04;

sealed class MistRiasSonicGuardian : Creature
{
    public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, 2000,
        Race.Guardian, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(
                new YouMayDrawCardsEffect(1)));
    }
}