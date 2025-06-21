namespace Cards.DM01
{
    class AquaKnight : Engine.Creature
    {
        public AquaKnight() : base("Aqua Knight", 5, 4000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
