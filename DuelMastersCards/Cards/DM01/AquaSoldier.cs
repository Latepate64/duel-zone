using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class AquaSoldier : Creature
    {
        public AquaSoldier() : base("Aqua Soldier", 3, Civilization.Water, 1000, Subtype.LiquidPeople)
        {
            // When this creature would be destroyed, return it to your hand instead.
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedReturnItToYourHandInsteadAbility());
        }
    }
}
