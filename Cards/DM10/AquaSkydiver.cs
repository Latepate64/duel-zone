using ContinuousEffects;

namespace Cards.DM10
{
    class AquaSkydiver : Engine.Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Light, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
