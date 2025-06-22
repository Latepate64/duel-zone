using ContinuousEffects;

namespace Cards.DM08
{
    sealed class AquaRanger : Engine.Creature
    {
        public AquaRanger() : base("Aqua Ranger", 6, 3000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
