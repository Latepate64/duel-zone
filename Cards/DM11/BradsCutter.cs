namespace Cards.DM11
{
    sealed class BradsCutter : Creature
    {
        public BradsCutter() : base("Brad's Cutter", 2, 1000, Interfaces.Race.Xenoparts, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
        }
    }
}
