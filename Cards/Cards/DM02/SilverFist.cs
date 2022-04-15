namespace Cards.Cards.DM02
{
    class SilverFist : Creature
    {
        public SilverFist() : base("Silver Fist", 4, 3000, Engine.Subtype.BeastFolk, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
