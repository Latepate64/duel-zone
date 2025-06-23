using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class EnigmaticCascade : Spell
{
    public EnigmaticCascade() : base("Enigmatic Cascade", 4, Civilization.Water)
    {
        AddSpellAbilities(new EnigmaticCascadeEffect());
    }
}
