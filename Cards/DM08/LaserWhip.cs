using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM08;

public sealed class LaserWhip : Spell
{
    public LaserWhip() : base("Laser Whip", 4, Civilization.Light)
    {
        AddSpellAbilities(new LaserWhipEffect());
    }
}
