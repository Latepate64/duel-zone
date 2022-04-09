using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class EachCivilizationCardCostsMoreEffect : ContinuousEffect, ICostModifyingEffect
    {
        private readonly Civilization _civilization;
        private readonly int _increase;

        public EachCivilizationCardCostsMoreEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
            _increase = effect._increase;
        }

        public EachCivilizationCardCostsMoreEffect(Civilization civilization, int increase) : base()
        {
            _civilization = civilization;
            _increase = increase;
        }

        public override ContinuousEffect Copy()
        {
            return new EachCivilizationCardCostsMoreEffect(this);
        }

        public int GetChange(Engine.ICard card, Engine.IGame game)
        {
            return card.HasCivilization(_civilization) ? _increase : 0;
        }

        public override string ToString()
        {
            return $"Each {_civilization} creature costs {_increase} more to summon, and each {_civilization} spell costs {_increase} more to cast.";
        }
    }
}
