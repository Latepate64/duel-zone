namespace Cards.Cards.DM01
{
    class Stonesaur : Creature
    {
        public Stonesaur() : base("Stonesaur", 5, 4000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
