using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM01;

sealed class AquaSniper : Creature
{
    public AquaSniper() : base("Aqua Sniper", 8, 5000, Race.LiquidPeople,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                    0, 2, new CreatureFilter()
                )));
    }
}