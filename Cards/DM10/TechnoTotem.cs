using Abilities;
using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class TechnoTotem : Creature
{
    public TechnoTotem() : base("Techno Totem", 4, 5000, Race.MysteryTotem,
        Civilization.Light, Civilization.Nature)
    {
        AddStaticAbilities(
            new WhileThisCreatureIsTappedEachOfYourOtherCreaturesHasAbilitiesEffect(
                new CreatureFilter(),
                new StaticAbility(new PowerAttackerEffect(1500))
            )
        );
        AddAbilities(new TapAbility(
            new ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
    }
}
