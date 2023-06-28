using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class EachOtherCivilizationCreaturePowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly Civilization _civilization;
        private readonly int _power;

        protected EachOtherCivilizationCreaturePowerEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
            _power = effect._power;
        }

        protected EachOtherCivilizationCreaturePowerEffect(Civilization civilization, int power) : base()
        {
            _civilization = civilization;
            _power = power;
        }

        public void ModifyPower()
        {
            Game.BattleZone.Creatures.Where(x => !IsSourceOfAbility(x)).ToList().ForEach(x => x.Power += _power);
        }

        public override string ToString()
        {
            return $"Each other {_civilization} creature in the battle zone gets +{_power} power.";
        }
    }
}
