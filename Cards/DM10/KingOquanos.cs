using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

sealed class KingOquanos : Creature
{
    public KingOquanos(
        ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("King Oquanos", 8, 2000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(
            new GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000),
            factory.Create(6000, doubleBreakerAbilityFactory.Create()));
    }
}
