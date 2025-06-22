namespace Cards.DM06
{
    sealed class SlumberShell : Engine.Creature
    {
        public SlumberShell() : base("Slumber Shell", 2, 2000, Interfaces.Race.ColonyBeetle, Interfaces.Civilization.Nature)
        {
        }
    }
}
