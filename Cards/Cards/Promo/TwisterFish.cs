namespace Cards.Cards.Promo
{
    class TwisterFish : Creature
    {
        public TwisterFish() : base("Twister Fish", 5, 3000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
