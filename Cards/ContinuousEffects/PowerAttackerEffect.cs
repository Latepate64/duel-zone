using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PowerAttackerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly int _power;

        public PowerAttackerEffect(PowerAttackerEffect effect) : base(effect)
        {
            _power = effect._power;
        }

        public PowerAttackerEffect(int power) : base()
        {
            _power = power;
        }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            var creature = GetSourceCard(game);
            if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && phase.AttackingCreature == creature)
            {
                creature.Power += _power;
            }
        }

        public override string ToString()
        {
            return $"Power attacker +{_power}";
        }
    }
}
