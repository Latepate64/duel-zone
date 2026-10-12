using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

sealed class SquawkingLunatron : SilentSkillCreature
{
    public SquawkingLunatron() : base("Squawking Lunatron", 5, 4000,
        Race.CyberMoon, Civilization.Water)
    {
        AddSilentSkillAbility(
            new ManaRecoveryEffect(
                minimum: 0,
                maximum: 3,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                ownMana: true
        ));
    }
}