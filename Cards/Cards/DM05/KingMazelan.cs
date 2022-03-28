using Common;

namespace Cards.Cards.DM05
{
    class KingMazelan : Creature
    {
        public KingMazelan() : base("King Mazelan", 8, 7000, Subtype.Leviathan, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
            AddDoubleBreakerAbility();
        }
    }
}
