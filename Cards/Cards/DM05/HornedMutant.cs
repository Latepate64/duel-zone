using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM05
{
    class HornedMutant : Creature
    {
        public HornedMutant() : base("Horned Mutant", 5, 3000, Engine.Subtype.Hedrian, Civilization.Darkness)
        {
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Civilization.Nature, 1));
        }
    }
}
