namespace Cards.DM01
{
    class AquaSoldier : Engine.Creature
    {
        public AquaSoldier() : base("Aqua Soldier", 3, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
