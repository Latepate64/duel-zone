using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class AquaKnight : Creature
    {
        public AquaKnight() : base("Aqua Knight", 5, 4000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            // When this creature would be destroyed, return it to your hand instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
