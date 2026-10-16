using Abilities;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

public sealed class KachuaKeeperOfTheIcegate : Creature
{
    public KachuaKeeperOfTheIcegate() : base("Kachua, Keeper of the Icegate", 7,
        3000, Race.SnowFaerie, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new KachuaEffect(
                    new KachuaContinuousEffectFactory(),
                    new KachuaDelayedTriggeredAbilityFactory()
                )));
    }
}
