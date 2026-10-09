using Abilities.Static;
using ContinuousEffects.Replacement;

namespace Cards.DM10
{
    sealed class AquaSkydiver : Creature
    {
        public AquaSkydiver() : base("Aqua Skydiver", 4, 1000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Light, Interfaces.Civilization.Water)
        {
            AddShieldTrigger();
            AddAbilities(new BlockerAbility());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
