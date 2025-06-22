using Engine;
using Interfaces;

namespace Cards.DM05;

public class ThunderNet : Spell
{
    public ThunderNet() : base("Thunder Net", 2, Civilization.Water)
    {
        AddSpellAbilities(new ThunderNetEffect());
    }
}
