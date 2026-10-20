using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using ContinuousEffects.CanAttackUntappedCreatures;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

public sealed class SmashWarriorStagrandu : Creature
{
    public SmashWarriorStagrandu() : base("Smash Warrior Stagrandu", 2, 1000, Race.Armorloid, Civilization.Fire)
    {
        AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect(new CreatureFilter()));
        AddTriggeredAbility(
            new StagranduAbility(
                new AddCreatureAffectingNumberEffect(
                    9000,
                    new ThisCreatureGetsPowerUntilTheEndOfTheTurnEffectFactory(),
                    new UntilEndOfThisTurnDuration())));
    }
}
