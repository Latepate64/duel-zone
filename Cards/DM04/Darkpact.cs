using Engine;
using Interfaces;

namespace Cards.DM04;

public class Darkpact : Spell
{
    public Darkpact() : base("Darkpact", 2, Civilization.Darkness)
    {
        AddSpellAbilities(new DarkpactEffect());
    }
}
