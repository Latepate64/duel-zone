using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM10
{
    class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000, Engine.Subtype.LiquidPeople, Civilization.Light, Civilization.Water)
        {
            AddShieldTrigger();
            AddBlockerAbility();
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
