namespace Cards.Cards.DM12
{
    class PeppiPepper : Creature
    {
        public PeppiPepper() : base("Peppi Pepper", 3, 2000, Engine.Race.FireBird, Engine.Civilization.Fire)
        {
            AddPowerAttackerAbility(3000);
        }
    }
}
