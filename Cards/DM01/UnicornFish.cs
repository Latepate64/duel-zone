using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM01;

sealed class UnicornFish : Creature
{
    public UnicornFish() : base("Unicorn Fish", 4, 1000, Race.Fish,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                    0, 1, new CreatureFilter()
                )));
    }
}