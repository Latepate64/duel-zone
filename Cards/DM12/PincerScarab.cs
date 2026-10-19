using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM12;

public sealed class PincerScarab : Creature
{
    public PincerScarab(
        ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory) : base(
            "Pincer Scarab", 4, 1000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(
            new PincerScarabEffect(),
            factory.Create(6000, doubleBreakerAbilityFactory.Create()));
    }
}
