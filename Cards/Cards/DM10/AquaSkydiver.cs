using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM10
{
    class AquaSkydiver : Engine.Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000, Engine.Race.LiquidPeople, Engine.Civilization.Light, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
