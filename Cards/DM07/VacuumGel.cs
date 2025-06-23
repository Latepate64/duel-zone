using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class VacuumGel : Spell
{
    public VacuumGel() : base("Vacuum Gel", 4, Civilization.Darkness)
    {
        AddSpellAbilities(new VacuumGelEffect());
    }
}
