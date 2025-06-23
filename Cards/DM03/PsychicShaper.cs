using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class PsychicShaper : Spell
{
    public PsychicShaper() : base("Psychic Shaper", 6, Civilization.Water)
    {
        AddSpellAbilities(new PsychicShaperEffect());
    }
}
