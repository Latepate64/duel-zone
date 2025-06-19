using Cards.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class AquaRanger : Engine.Creature
    {
        public AquaRanger() : base("Aqua Ranger", 6, 3000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
