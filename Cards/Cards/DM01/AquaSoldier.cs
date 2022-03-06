using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class AquaSoldier : Creature
    {
        public AquaSoldier() : base("Aqua Soldier", 3, 1000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            // When this creature would be destroyed, return it to your hand instead.
            AddAbilities(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
