namespace Cards.Cards.DM01
{
    class Stonesaur : Creature
    {
        public Stonesaur() : base("Stonesaur", 5, 4000, Engine.Subtype.RockBeast, Common.Civilization.Fire)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
