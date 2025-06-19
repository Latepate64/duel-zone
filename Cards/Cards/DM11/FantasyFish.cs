using Cards.ContinuousEffects;

namespace Cards.Cards.DM11
{
    class FantasyFish : Engine.Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, 2000, Engine.Race.GelFish, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
