using Engine;
using Interfaces;

namespace Cards.DM11;

public sealed class MiraculousTruce : Spell
{
    public MiraculousTruce() : base("Miraculous Truce", 5, Civilization.Light, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(new MiraculousTruceEffect());
    }
}
