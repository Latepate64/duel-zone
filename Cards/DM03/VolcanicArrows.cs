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
            new ChooseAndDestroyCreatureEffect(new MaxPowerFilter(6000)),
            new ChooseOneOfYourShieldsAndPutItIntoYourGraveyardEffect());
    }
}