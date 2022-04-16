namespace Cards.Cards.DM05
{
    class SyriusFirmamentElemental : Creature
    {
        public SyriusFirmamentElemental() : base("Syrius, Firmament Elemental", 11, 12000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddTripleBreakerAbility();
        }
    }
}
