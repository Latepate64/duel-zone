namespace Cards.Cards.DM01
{
    class ZagaanKnightOfDarkness : Creature
    {
        public ZagaanKnightOfDarkness() : base("Zagaan, Knight of Darkness", 6, 7000, Engine.Subtype.DemonCommand, Engine.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
        }
    }
}
