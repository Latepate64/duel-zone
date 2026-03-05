using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class FreezingIcehammer : Spell
{
    public FreezingIcehammer() : base("Freezing Icehammer", 3, Civilization.Nature)
    {
        AddSpellAbilities(new FreezingIcehammerEffect());
    }
}
