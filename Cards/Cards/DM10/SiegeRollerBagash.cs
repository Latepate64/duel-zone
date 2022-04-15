namespace Cards.Cards.DM10
{
    class SiegeRollerBagash : Creature
    {
        public SiegeRollerBagash() : base("Siege Roller Bagash", 4, 3000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ContinuousEffects.DogarnTheMarauderEffect(1000));
        }
    }
}
