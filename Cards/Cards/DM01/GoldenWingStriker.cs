namespace Cards.Cards.DM01
{
    class GoldenWingStriker : Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, 2000, Engine.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
