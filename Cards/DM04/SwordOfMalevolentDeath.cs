using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class SwordOfMalevolentDeath : Spell
{
    public SwordOfMalevolentDeath() : base("Sword of Malevolent Death", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new SwordOfMalevolentDeathOneShotEffect());
    }
}
