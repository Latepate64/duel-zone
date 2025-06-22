namespace Cards.DM10
{
    sealed class SiegeRollerBagash : Engine.Creature
    {
        public SiegeRollerBagash() : base("Siege Roller Bagash", 4, 3000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(1000));
        }
    }
}
