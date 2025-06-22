using ContinuousEffects;

namespace Cards.DM11
{
    sealed class FantasyFish : Engine.Creature
    {
        public FantasyFish() : base("Fantasy Fish", 7, 2000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
