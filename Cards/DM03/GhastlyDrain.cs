using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class GhastlyDrain : Spell
{
    public GhastlyDrain() : base("Ghastly Drain", 3, Civilization.Darkness)
    {
        AddSpellAbilities(new GhastlyDrainEffect());
    }
}
