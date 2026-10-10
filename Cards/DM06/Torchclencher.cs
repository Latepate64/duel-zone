using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM06;

public sealed class Torchclencher : Creature
{
    public Torchclencher() : base("Torchclencher", 3, 2000, Race.Dragonoid,
        Civilization.Fire)
    {
        AddStaticAbilities(
            new WhileYouControlAtLeastOneOtherCreatureThisCreatureHasAbilityEffect(
                new StaticAbility(new PowerAttackerEffect(3000)),
                new CivilizationCreatureFilter(Civilization.Fire)
            ));
    }
}
