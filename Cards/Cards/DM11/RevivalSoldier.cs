namespace Cards.Cards.DM11
{
    class RevivalSoldier : WaveStrikerCreature
    {
        public RevivalSoldier() : base("Revival Soldier", 3, 2000, Engine.Subtype.Merfolk, Engine.Civilization.Water)
        {
            AddWaveStrikerAbility(new ContinuousEffects.ThisCreatureGetsPowerEffect(4000), new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
