using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class EachOtherCivilizationCreaturePowerEffect : PowerModifyingEffect
    {
        private readonly Civilization _civilization;

        public EachOtherCivilizationCreaturePowerEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public EachOtherCivilizationCreaturePowerEffect(Civilization civilization, int power) : base(power, new CardFilters.AnotherBattleZoneCivilizationCreatureFilter(civilization), new Durations.Indefinite())
        {
            _civilization = civilization;
        }

        public override ContinuousEffect Copy()
        {
            return new EachOtherCivilizationCreaturePowerEffect(this);
        }

        public override string ToString()
        {
            return $"Each other {_civilization} creature in the battle zone gets +{_power} power.";
        }
    }
}
