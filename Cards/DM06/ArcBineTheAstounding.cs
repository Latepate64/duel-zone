using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class ArcBineTheAstounding : EvolutionCreature
{
    public ArcBineTheAstounding() : base("Arc Bine, the Astounding", 5, 5000,
        Race.Guardian, Civilization.Light)
    {
        AddStaticAbilities(
            new TapAbilityAddingEffect(
                new TapChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCards
                ),
                new CivilizationCreatureFilter(Civilization.Light)));
    }
}