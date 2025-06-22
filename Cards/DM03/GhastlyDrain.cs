using Engine;
using Interfaces;

namespace Cards.DM03;

public class GhastlyDrain : Spell
{
    public GhastlyDrain() : base("Ghastly Drain", 3, Civilization.Darkness)
    {
        AddSpellAbilities(new GhastlyDrainEffect());
    }
}
