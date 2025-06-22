using Engine;
using Interfaces;

namespace Cards.DM12;

public class EnigmaticCascade : Spell
{
    public EnigmaticCascade() : base("Enigmatic Cascade", 4, Civilization.Water)
    {
        AddSpellAbilities(new EnigmaticCascadeEffect());
    }
}
