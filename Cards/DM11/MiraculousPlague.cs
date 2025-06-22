using Engine;
using Interfaces;

namespace Cards.DM11;

public sealed class MiraculousPlague : Spell
{
    public MiraculousPlague() : base("Miraculous Plague", 7, Civilization.Water, Civilization.Darkness)
    {
        AddSpellAbilities(new MiraculousPlagueEffect());
    }
}
