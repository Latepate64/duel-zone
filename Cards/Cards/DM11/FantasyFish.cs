namespace Cards.Cards.DM11
{
    class FantasyFish : Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, 2000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddBlockerAbility();
        }
    }
}
