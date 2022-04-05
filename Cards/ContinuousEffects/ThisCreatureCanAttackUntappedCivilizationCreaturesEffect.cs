using Cards.CardFilters;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(ThisCreatureCanAttackUntappedCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization civilization) : base(new TargetFilter())
        {
            _civilization = civilization;
        }

        public bool Applies(Engine.ICard targetOfAttack, IGame game)
        {
            return targetOfAttack.HasCivilization(_civilization);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can attack untapped {_civilization.ToString().ToLower()} creatures.";
        }
    }
}