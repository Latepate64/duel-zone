using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class PowerAttackerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly int _power;

        public PowerAttackerEffect(PowerAttackerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public PowerAttackerEffect(int power) : this(power, new TargetFilter(), new Durations.Indefinite())
        {
        }

        public PowerAttackerEffect(int power, CardFilter filter, Duration duration) : base(filter)
        {
            _power = power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase)
            {
                GetAffectedCards(game).Where(x => x.Id == phase.AttackingCreature).ToList().ForEach(x => x.Power += _power);
            }
        }

        public override string ToString()
        {
            return $"Power attacker +{_power}";
        }
    }
}
