namespace Cards.Cards.Promo
{
    class TwisterFish : Engine.Creature
    {
        public TwisterFish() : base("Twister Fish", 5, 3000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
