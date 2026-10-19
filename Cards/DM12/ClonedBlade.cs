using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class ClonedBlade : Spell
{
    public ClonedBlade() : base("Cloned Blade", 5, Civilization.Fire)
    {
        AddSpellAbilities(
            new ClonedBladeEffect(
                Name,
                new MaxPowerFilter(3000)));
    }
}
