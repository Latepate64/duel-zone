namespace Cards.DM10
{
    class SiegeRollerBagash : Engine.Creature
    {
        public SiegeRollerBagash() : base("Siege Roller Bagash", 4, 3000, Engine.Race.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(1000));
        }
    }
}
