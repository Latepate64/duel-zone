using Abilities;
using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class Sopian : Creature
{
    public Sopian() : base("Sopian", 4, 2000, Race.CyberLord,
        Civilization.Water)
    {
        AddAbilities(
            new TapAbility(
                new YourChosenCreaturesCannotBeBlockedEffect(
                    minimum: 1,
                    maximum: 1,
                    filter: new CreatureFilter(),
                    factory: new ChosenCreaturesCannotBeBlockedEffectFactory(),
                    new UntilEndOfThisTurnDuration()
                )));
    }
}