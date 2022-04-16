namespace Cards.Cards.Promo
{
    class TwisterFish : Creature
    {
        public TwisterFish() : base("Twister Fish", 5, 3000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
