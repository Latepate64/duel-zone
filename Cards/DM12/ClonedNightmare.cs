using Interfaces;
using OneShotEffects;

namespace Cards.DM12;

public sealed class ClonedNightmare : Spell
{
    public ClonedNightmare() : base("Cloned Nightmare", 3, Civilization.Darkness)
    {
        AddSpellAbilities(new ClonedNightmareEffect(Name));
    }
}
