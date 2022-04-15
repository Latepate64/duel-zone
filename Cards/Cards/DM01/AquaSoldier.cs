namespace Cards.Cards.DM01
{
    class AquaSoldier : Creature
    {
        public AquaSoldier() : base("Aqua Soldier", 3, 1000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
