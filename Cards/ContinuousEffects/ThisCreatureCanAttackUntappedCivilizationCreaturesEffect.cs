using Cards.CardFilters;
using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesEffect : CanAttackUntappedCreaturesEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(ThisCreatureCanAttackUntappedCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization civilization) : base(new Engine.TargetFilter(), new OpponentsBattleZoneUntappedCivilizationCreatureFilter(civilization), new Durations.Indefinite())
        {
            _civilization = civilization;
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