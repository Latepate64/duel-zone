using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class TechnoTotem : Creature
{
    public TechnoTotem() : base("Techno Totem", 4, 5000, Race.MysteryTotem,
        Civilization.Light, Civilization.Nature)
    {
        AddStaticAbilities(
            new EachOfYourOtherCreaturesHasAbilityEffect(
                new CreatureFilter(),
                new PowerAttackerAbility(1500),
                new CreatureIsTappedCondition()
            )
        );
        AddAbilities(
            new TapAbility(
                new TapChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCards
                )));
    }
}
