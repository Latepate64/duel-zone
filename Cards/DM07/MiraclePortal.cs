using Engine;
using Interfaces;

namespace Cards.DM07;

public sealed class MiraclePortal : Spell
{
    public MiraclePortal() : base("Miracle Portal", 4, Civilization.Light)
    {
        AddSpellAbilities(new MiraclePortalOneShotEffect());
    }
}
