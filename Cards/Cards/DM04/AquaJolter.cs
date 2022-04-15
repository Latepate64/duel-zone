using Common;

namespace Cards.Cards.DM04
{
    class AquaJolter : Creature
    {
        public AquaJolter() : base("Aqua Jolter", 3, 2000, Engine.Subtype.LiquidPeople, Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
