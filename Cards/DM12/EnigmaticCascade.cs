using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class EnigmaticCascade : Spell
{
    public EnigmaticCascade() : base("Enigmatic Cascade", 4, Civilization.Water)
    {
        AddSpellAbilities(new EnigmaticCascadeEffect());
    }
}
