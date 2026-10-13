using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class FlohdaniTheSpydroid : SilentSkillCreature
{
    public FlohdaniTheSpydroid() : base("Flohdani, the Spydroid", 4, 4000,
        Race.Soltrooper, Civilization.Light)
    {
        AddSilentSkillAbility(
            new TapChoiceEffect(
                minimum: 0,
                maximum: 2,
                ownerChooses: true,
                filter: new CreatureFilter(),
                selectionRange: SelectionRange.OpponentsCards
            ));
    }
}