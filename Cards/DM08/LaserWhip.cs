using Engine;
using Interfaces;

namespace Cards.DM08;

public class LaserWhip : Spell
{
    public LaserWhip() : base("Laser Whip", 4, Civilization.Light)
    {
        AddSpellAbilities(new LaserWhipEffect());
    }
}
