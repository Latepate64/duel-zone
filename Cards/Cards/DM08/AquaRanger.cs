using Cards.ContinuousEffects;

namespace Cards.Cards.DM08
{
    class AquaRanger : Creature
    {
        public AquaRanger() : base("Aqua Ranger", 6, 3000, Engine.Subtype.LiquidPeople, Engine.Civilization.Water)
        {
            AddThisCreatureCannotBeBlockedAbility();
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadEffect());
        }
    }
}
