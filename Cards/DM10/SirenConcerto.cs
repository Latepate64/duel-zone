using Engine;
using Interfaces;

namespace Cards.DM10;

public class SirenConcerto : Spell
{
    public SirenConcerto() : base("Siren Concerto", 1, Civilization.Water)
    {
        AddShieldTrigger();
        AddSpellAbilities(new SirenConcertoEffect());
    }
}
