using Common;

namespace Cards.Cards.DM05
{
    class HornedMutant : Creature
    {
        public HornedMutant() : base("Horned Mutant", 5, 3000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.EachCivilizationCardCostsMoreAbility(Civilization.Nature, 1));
        }
    }
}
