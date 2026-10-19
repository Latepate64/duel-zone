using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class RainbowGate : Spell
{
    public RainbowGate() : base("Rainbow Gate", 2, Civilization.Nature)
    {
        AddSpellAbilities(
            new SearchEffect(
                reveal: true,
                filter: new MultiColoredCreatureFilter()
        ));
    }
}
