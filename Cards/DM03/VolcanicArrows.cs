using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class VolcanicArrows : Spell
{
    public VolcanicArrows() : base("Volcanic Arrows", 2, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MaxPowerFilter(6000),
                selectionRange: SelectionRange.AllCreatures
            ),
            new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
    }
}