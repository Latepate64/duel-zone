namespace Cards.Cards.DM06
{
    class CarrierShell : Creature
    {
        public CarrierShell() : base("Carrier Shell", 3, 2000, Engine.Subtype.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
        }
    }
}
