using Abilities;
using StaticAbilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

public sealed class KachuaKeeperOfTheIcegate : Creature
{
    public KachuaKeeperOfTheIcegate(
        TapAbilityFactory tapAbilityFactory,
        KachuaEffectFactory kachuaEffectFactory,
        ThatCreatureHasAbilityEffectFactory thatCreatureHasAbilityEffectFactory,
        KachuaDelayedTriggeredAbilityFactory kachuaDelayedTriggeredAbilityFactory,
        SpeedAttackerAbilityFactory speedAttackerAbilityFactory)
        : base("Kachua, Keeper of the Icegate", 7, 3000, Race.SnowFaerie, Civilization.Nature)
    {
        AddAbilities(
            tapAbilityFactory.Create(
                kachuaEffectFactory.Create(
                    thatCreatureHasAbilityEffectFactory,
                    kachuaDelayedTriggeredAbilityFactory,
                    speedAttackerAbilityFactory.Create(),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}
