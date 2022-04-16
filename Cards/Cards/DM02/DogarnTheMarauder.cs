namespace Cards.Cards.DM02
{
    class DogarnTheMarauder : Creature
    {
        public DogarnTheMarauder() : base("Dogarn, the Marauder", 3, 2000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(2000));
        }
    }
}
