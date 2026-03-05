using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class CreepingPlague : Spell
{
    public CreepingPlague() : base("Creeping Plague", 1, Civilization.Darkness)
    {
        AddSpellAbilities(new CreepingPlagueEffect());
    }
}
