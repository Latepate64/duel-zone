using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class AquaKnight : Creature
    {
        public AquaKnight() : base("Aqua Knight", 5, Civilization.Water, 4000, Subtype.LiquidPeople)
        {
            // When this creature would be destroyed, return it to your hand instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
