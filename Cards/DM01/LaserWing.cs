using Engine;
using Interfaces;

namespace Cards.DM01;

public sealed class LaserWing : Spell
{
    public LaserWing() : base("Laser Wing", 5, Civilization.Light)
    {
        AddSpellAbilities(new LaserWingEffect());
    }
}
