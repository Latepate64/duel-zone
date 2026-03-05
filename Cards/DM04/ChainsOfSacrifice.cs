using OneShotEffects;
using Interfaces;

namespace Cards.DM04;

public sealed class ChainsOfSacrifice : Spell
{
    public ChainsOfSacrifice() : base("Chains of Sacrifice", 8, Civilization.Darkness)
    {
        AddSpellAbilities(new ChainsOfSacrificeEffect(), new SacrificeEffect());
    }
}
