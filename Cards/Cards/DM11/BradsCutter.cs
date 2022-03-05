using Common;

namespace Cards.Cards.DM11
{
    class BradsCutter : Creature
    {
        public BradsCutter() : base("Brad's Cutter", 2, Civilization.Fire, 1000, Subtype.Xenoparts)
        {
            ShieldTrigger = true;
        }
    }
}
