namespace Cards.Cards.DM05
{
    class BolgashDragon : Creature
    {
        public BolgashDragon() : base("Bolgash Dragon", 8, 4000, Engine.Subtype.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(8000);
            AddTripleBreakerAbility();
        }
    }
}
