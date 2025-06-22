using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class CrisisBoulder : Spell
{
    public CrisisBoulder() : base("Crisis Boulder", 4, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(new CrisisBoulderEffect());
    }
}
