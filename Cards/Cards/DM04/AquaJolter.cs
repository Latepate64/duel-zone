using Common;

namespace Cards.Cards.DM04
{
    class AquaJolter : Creature
    {
        public AquaJolter() : base("Aqua Jolter", 3, Civilization.Water, 2000, Subtype.LiquidPeople)
        {
            ShieldTrigger = true;
        }
    }
}
