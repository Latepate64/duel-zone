using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    abstract class EachCivilizationCardCostsMoreEffect : ContinuousEffect, ICostModifyingEffect, ICivilizationable
    {
        private readonly int _increase;

        protected EachCivilizationCardCostsMoreEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
            _increase = effect._increase;
        }

        protected EachCivilizationCardCostsMoreEffect(int increase, Civilization civilization) : base()
        {
            Civilization = civilization;
            _increase = increase;
        }

        public Civilization Civilization { get; }

        public int GetChange(ICard card, IGame game)
        {
            return card.HasCivilization(Civilization) ? _increase : 0;
        }

        public override string ToString()
        {
            return $"Each {Civilization} creature costs {_increase} more to summon, and each {Civilization} spell costs {_increase} more to cast.";
        }
    }
}
