using Engine;
using Interfaces;

namespace Cards.DM04;

public class SoulGulp : Spell
{
    public SoulGulp() : base("Soul Gulp", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new SoulGulpEffect());
    }
}
