using Engine;

namespace Cards.DM02;

public sealed class EssenceElf : Creature
{
    public EssenceElf() : base("Essence Elf", 2, 1000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
    {
        AddStaticAbilities(new EssenceElfEffect());
    }
}
