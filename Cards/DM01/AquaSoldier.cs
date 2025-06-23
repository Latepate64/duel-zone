namespace Cards.DM01
{
    sealed class AquaSoldier : Creature
    {
        public AquaSoldier() : base("Aqua Soldier", 3, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
