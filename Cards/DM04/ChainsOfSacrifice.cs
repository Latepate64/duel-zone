using OneShotEffects;
using Engine;
using Interfaces;

namespace Cards.DM04;

public class ChainsOfSacrifice : Spell
{
    public ChainsOfSacrifice() : base("Chains of Sacrifice", 8, Civilization.Darkness)
    {
        AddSpellAbilities(new ChainsOfSacrificeEffect(), new SacrificeEffect());
    }
}
