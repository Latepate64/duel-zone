namespace Cards.Cards.DM02
{
    class UltracideWorm : EvolutionCreature
    {
        public UltracideWorm() : base("Ultracide Worm", 6, 11000, Engine.Race.ParasiteWorm, Engine.Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
        }
    }
}
