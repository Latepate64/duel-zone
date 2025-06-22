using Engine;

namespace Cards.DM02;

public class ElfX : Creature
{
    public ElfX() : base("Elf-X", 4, 2000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
    {
        AddStaticAbilities(new ElfXEffect());
    }
}
