using Abilities.Static;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;

namespace Cards.DM07;

sealed class GazariasDragon : Creature
{
    public GazariasDragon(
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("Gazarias Dragon", 5, 4000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerAndAbilityEffect(
                4000,
                doubleBreakerAbilityFactory.Create(),
                new PlayerHasNoShieldsCondition()
        ));
    }
}
