using Common;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class EachOtherCivilizationCreaturePowerAbility : Engine.Abilities.StaticAbility
    {
        public EachOtherCivilizationCreaturePowerAbility(Civilization civilization, int power) : base(new EachOtherCivilizationCreaturePowerEffect(civilization, power))
        {
        }
    }

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