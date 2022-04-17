namespace Cards.Cards.DM02
{
    class LadiaBaleTheInspirational : EvolutionCreature
    {
        public LadiaBaleTheInspirational() : base("Ladia Bale, the Inspirational", 6, 9500, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddDoubleBreakerAbility();
        }
    }
}
