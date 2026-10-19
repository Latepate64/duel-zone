using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class QuixoticHeroSwineSnout : Creature
{
    public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, 1000,
        Race.BeastFolk, Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(
                new AddCreatureAffectingNumberEffect(
                    3000,
                    new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory(),
                    new UntilEndOfThisTurnDuration())));
    }
}