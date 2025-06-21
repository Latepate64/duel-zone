using ContinuousEffects;

namespace Cards.DM11
{
    class FantasyFish : Engine.Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, 2000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
