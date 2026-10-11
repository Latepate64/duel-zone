using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class FortMegacluster : EvolutionCreature
{
    public FortMegacluster() : base("Fort Megacluster", 5, 5000,
        Race.CyberCluster, Civilization.Water)
    {
        AddStaticAbilities(
            new TapAbilityAddingEffect(
                new DrawCardEffect(),
                new CivilizationCreatureFilter(Civilization.Water)));
    }
}