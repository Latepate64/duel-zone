using Engine;
using Interfaces;

namespace Cards.DM03;

public class PsychicShaper : Spell
{
    public PsychicShaper() : base("Psychic Shaper", 6, Civilization.Water)
    {
        AddSpellAbilities(new PsychicShaperEffect());
    }
}
