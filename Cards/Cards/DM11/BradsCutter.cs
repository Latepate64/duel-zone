namespace Cards.Cards.DM11
{
    class BradsCutter : Creature
    {
        public BradsCutter() : base("Brad's Cutter", 2, 1000, Engine.Subtype.Xenoparts, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
        }
    }
}
