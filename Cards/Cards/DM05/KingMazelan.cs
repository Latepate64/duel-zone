namespace Cards.Cards.DM05
{
    class KingMazelan : Creature
    {
        public KingMazelan() : base("King Mazelan", 8, 7000, Engine.Subtype.Leviathan, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect());
            AddDoubleBreakerAbility();
        }
    }
}
