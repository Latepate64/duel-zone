using Common;

namespace Cards.Cards.DM04
{
    class GregorianWorm : Creature
    {
        public GregorianWorm() : base("Gregorian Worm", 4, 3000, Engine.Subtype.ParasiteWorm, Civilization.Darkness)
        {
            AddShieldTrigger();
        }
    }
}
