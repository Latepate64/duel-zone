using Common;

namespace Cards.Cards.Promo
{
    class TwisterFish : Creature
    {
        public TwisterFish() : base("Twister Fish", 5, 3000, Engine.Subtype.GelFish, Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
