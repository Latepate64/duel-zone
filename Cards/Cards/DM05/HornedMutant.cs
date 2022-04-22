using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class HornedMutant : Creature
    {
        public HornedMutant() : base("Horned Mutant", 5, 3000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new HornedMutantEffect());
        }
    }

    class HornedMutantEffect : EachCivilizationCardCostsMoreEffect
    {
        public HornedMutantEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public HornedMutantEffect(Engine.Civilization civilization = Engine.Civilization.Nature) : base(1, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new HornedMutantEffect(this);
        }
    }
}
