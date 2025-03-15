using Cards.ContinuousEffects;

namespace Cards.Cards.DM10
{
    public class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000, Engine.Race.LiquidPeople, Engine.Civilization.Light, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddBlockerAbility();
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
