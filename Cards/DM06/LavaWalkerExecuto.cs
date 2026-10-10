using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class LavaWalkerExecuto : EvolutionCreature
{
    public LavaWalkerExecuto() : base("Lava Walker Executo", 4, 5000,
        Race.Dragonoid, Civilization.Fire)
    {
        AddStaticAbilities(
            new TapAbilityAddingEffect(
                new OneOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(
                    3000, new CivilizationCreatureFilter(Civilization.Fire)),
                new CivilizationCreatureFilter(Civilization.Fire)));
    }
}
