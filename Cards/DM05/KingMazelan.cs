using Abilities.Static;
using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class KingMazelan : Creature
{
    public KingMazelan() : base("King Mazelan", 8, 7000, Race.Leviathan,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                    0, 1, new CreatureFilter()
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}