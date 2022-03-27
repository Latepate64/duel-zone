using Cards.CardFilters;
using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCanAttackUntappedCivilizationCreaturesAbility(Civilization civilization) : base(new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(civilization)) { }
    }

    class ThisCreatureCanAttackUntappedCivilizationCreaturesEffect : CanAttackUntappedCreaturesEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(ThisCreatureCanAttackUntappedCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization civilization) : base(new TargetFilter(), new OpponentsBattleZoneUntappedCivilizationCreatureFilter(civilization), new Durations.Indefinite())
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
