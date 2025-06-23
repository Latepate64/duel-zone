using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class SoulGulp : Spell
{
    public SoulGulp() : base("Soul Gulp", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new SoulGulpEffect());
    }
}
