using Common;

namespace Cards.Cards.Promo
{
    class TwisterFish : Creature
    {
        public TwisterFish() : base("Twister Fish", 5, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
