using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class TerradragonDakmaBalgarow : Creature
{
    public TerradragonDakmaBalgarow(
        ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        TripleBreakerAbilityFactory tripleBreakerAbilityFactory
    ) : base("Terradragon Dakma Balgarow", 7, 1000, Race.EarthDragon, Civilization.Nature)
    {
        AddStaticAbilities(
            new TerradragonDakmaBalgarowEffect(),
            factory.Create(
                6000,
                doubleBreakerAbilityFactory.Create(),
                15000,
                tripleBreakerAbilityFactory.Create()));
    }
}
