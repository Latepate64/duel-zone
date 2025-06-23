using Engine;
using Interfaces;

namespace Cards.DM12;

public sealed class ClonedSpiral : Spell
{
    public ClonedSpiral() : base("Cloned Spiral", 4, Civilization.Water)
    {
        AddSpellAbilities(new ClonedSpiralEffect(Name));
    }
}
