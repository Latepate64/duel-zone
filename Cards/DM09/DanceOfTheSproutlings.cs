using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class DanceOfTheSproutlings : Spell
{
    public DanceOfTheSproutlings() : base("Dance of the Sproutlings", 3, Civilization.Nature)
    {
        AddSpellAbilities(new DanceOfTheSproutlingsEffect());
    }
}
