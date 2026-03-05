using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    sealed class KingMazelan : Creature
    {
        public KingMazelan() : base("King Mazelan", 8, 7000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
