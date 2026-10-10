using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class LegacyShell : Creature
{
    public LegacyShell() : base("Legacy Shell", 5, 4000, Race.ColonyBeetle,
        Civilization.Nature)
    {
        AddStaticAbilities(new EachOfYourCreaturesHasAbilityEffect(
            new StaticAbility(new PowerAttackerEffect(3000)),
            new CivilizationCreatureFilter(
                Civilization.Light, Civilization.Fire)));
    }
}
