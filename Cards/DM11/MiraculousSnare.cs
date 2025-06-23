using Engine;
using Interfaces;

namespace Cards.DM11;

public sealed class MiraculousSnare : Spell
{
    public MiraculousSnare() : base("Miraculous Snare", 3, Civilization.Light, Civilization.Water)
    {
        AddSpellAbilities(new MiraculousSnareEffect());
    }
}
