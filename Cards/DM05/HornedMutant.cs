using ContinuousEffects;
using Interfaces.ContinuousEffects;

namespace Cards.DM05
{
    class HornedMutant : Engine.Creature
    {
        public HornedMutant() : base("Horned Mutant", 5, 3000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new HornedMutantEffect());
        }
    }

    class HornedMutantEffect : EachCivilizationCardCostsMoreEffect
    {
        public HornedMutantEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public HornedMutantEffect(Interfaces.Civilization civilization = Interfaces.Civilization.Nature) : base(1, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HornedMutantEffect(this);
        }
    }
}
