using Engine;
using Interfaces;

namespace Cards.DM01;

public class CreepingPlague : Spell
{
    public CreepingPlague() : base("Creeping Plague", 1, Civilization.Darkness)
    {
        AddSpellAbilities(new CreepingPlagueEffect());
    }
}
