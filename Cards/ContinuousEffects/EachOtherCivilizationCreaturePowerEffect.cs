using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class EachOtherCivilizationCreaturePowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly Civilization _civilization;
        private readonly int _power;

        public EachOtherCivilizationCreaturePowerEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
            _power = effect._power;
        }

        public EachOtherCivilizationCreaturePowerEffect(Civilization civilization, int power) : base()
        {
            _civilization = civilization;
            _power = power;
        }

        public override ContinuousEffect Copy()
        {
            return new EachOtherCivilizationCreaturePowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.Creatures.Where(x => !IsSourceOfAbility(x, game)).ToList().ForEach(x => x.Power += _power);
        }

        public override string ToString()
        {
            return $"Each other {_civilization} creature in the battle zone gets +{_power} power.";
        }
    }
}
