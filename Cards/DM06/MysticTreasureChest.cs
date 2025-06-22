using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class MysticTreasureChest : Spell
{
    public MysticTreasureChest() : base("Mystic Treasure Chest", 3, Civilization.Nature)
    {
        AddSpellAbilities(new MysticTreasureChestEffect());
    }
}
