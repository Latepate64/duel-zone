namespace Cards.DM02
{
    class DogarnTheMarauder : Engine.Creature
    {
        public DogarnTheMarauder() : base("Dogarn, the Marauder", 3, 2000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(2000));
        }
    }
}
