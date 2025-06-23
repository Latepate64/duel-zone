using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class MiraculousRebirth : Spell
{
    public MiraculousRebirth() : base("Miraculous Rebirth", 6, Civilization.Fire, Civilization.Nature)
    {
        AddSpellAbilities(new MiraculousRebirthEffect());
    }
}
