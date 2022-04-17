using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class HornedMutant : Creature
    {
        public HornedMutant() : base("Horned Mutant", 5, 3000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Engine.Civilization.Nature, 1));
        }
    }
}
