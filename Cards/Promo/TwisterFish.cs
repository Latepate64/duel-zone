namespace Cards.Promo
{
    sealed class TwisterFish : Creature
    {
        public TwisterFish() : base("Twister Fish", 5, 3000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
        }
    }
}
