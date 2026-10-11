using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM04;

public sealed class ChainsOfSacrifice : Spell
{
    public ChainsOfSacrifice() : base("Chains of Sacrifice", 8,
        Civilization.Darkness)
    {
        AddSpellAbilities(
            new DestroyUpToOpponentsCreaturesEffect(
                2, new CreatureFilter()
            ),
            new SacrificeEffect());
    }
}
