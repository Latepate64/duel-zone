using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PowerAttackerEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable
    {
        public PowerAttackerEffect(PowerAttackerEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public PowerAttackerEffect(int power) : base()
        {
            Power = power;
        }

        public int Power { get; }

        public override ContinuousEffect Copy()
        {
            return new PowerAttackerEffect(this);
        }

        public void ModifyPower()
        {
            var creature = Source;
            if (Game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && phase.AttackingCreature == creature)
            {
                creature.Power += Power;
            }
        }

        public override string ToString()
        {
            return $"Power attacker +{Power}";
        }
    }
}
