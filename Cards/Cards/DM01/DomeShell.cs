namespace Cards.Cards.DM01
{
    class DomeShell : Creature
    {
        public DomeShell() : base("Dome Shell", 4, 3000, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
        }
    }
}
