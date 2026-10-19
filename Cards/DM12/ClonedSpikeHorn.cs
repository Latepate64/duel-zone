using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM12;

public sealed class ClonedSpikeHorn : Creature
{
    public ClonedSpikeHorn(
        ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("Cloned Spike-Horn", 4, 3000, Race.HornedBeast, Civilization.Nature)
    {
        AddStaticAbilities(
            new ClonedSpikeHornEffect(Name),
            factory.Create(6000, doubleBreakerAbilityFactory.Create()));
    }
}
