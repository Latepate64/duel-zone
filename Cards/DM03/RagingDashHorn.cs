using StaticAbilities;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;

namespace Cards.DM03;

public sealed class RagingDashHorn : Creature
{
    public RagingDashHorn(
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("Raging Dash-Horn", 5, 4000, Race.HornedBeast,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerAndAbilityEffect(
                3000,
                doubleBreakerAbilityFactory.Create(),
                new AllManaControllerHasHaveCivilizationCondition(Civilization.Nature)
        ));
    }
}
