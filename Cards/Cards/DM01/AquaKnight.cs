namespace Cards.Cards.DM01
{
    class AquaKnight : Creature
    {
        public AquaKnight() : base("Aqua Knight", 5, 4000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
