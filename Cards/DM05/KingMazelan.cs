using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    class KingMazelan : Engine.Creature
    {
        public KingMazelan() : base("King Mazelan", 8, 7000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
