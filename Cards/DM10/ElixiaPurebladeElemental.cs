using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class ElixiaPurebladeElemental : Creature
{
    public ElixiaPurebladeElemental(
        ThisCreatureHasEitherAbilityWhilePowerAtLeastEitherEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        TripleBreakerAbilityFactory tripleBreakerAbilityFactory
    ) : base("Elixia, Pureblade Elemental", 6, 1000, Race.AngelCommand, Civilization.Light)
    {
        AddStaticAbilities(
            new ElixiaEffect(),
            factory.Create(
                6000,
                doubleBreakerAbilityFactory.Create(),
                15000,
                tripleBreakerAbilityFactory.Create()));
    }
}
