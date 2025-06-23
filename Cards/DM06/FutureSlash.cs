using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class FutureSlash : Spell
{
    public FutureSlash() : base("Future Slash", 7, Civilization.Darkness)
    {
        AddSpellAbilities(new FutureSlashEffect());
    }
}
