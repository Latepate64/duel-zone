using Abilities;
using StaticAbilities;
using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class Biancus : Creature
{
    public Biancus() : base("Biancus", 6, 3000, Race.SeaHacker,
        Civilization.Water)
    {
        AddAbilities(new BlockerAbility());
        AddAbilities(
            new TapAbility(
                new YourChosenCreaturesCannotBeBlockedThisTurnEffect(
                    minimum: 1,
                    maximum: 1,
                    filter: new CreatureFilter(),
                    factory: new ChosenCreaturesCannotBeBlockedThisTurnEffectFactory()
                )));
    }
}