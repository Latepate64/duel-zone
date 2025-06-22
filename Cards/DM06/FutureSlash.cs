using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class FutureSlash : Spell
{
    public FutureSlash() : base("Future Slash", 7, Civilization.Darkness)
    {
        AddSpellAbilities(new FutureSlashEffect());
    }
}
