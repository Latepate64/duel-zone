using Engine;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class PowerAttackerEffect : PowerModifyingEffect
    {
        public PowerAttackerEffect(PowerModifyingEffect effect) : base(effect)
        {
        }

        public PowerAttackerEffect(int power, params Condition[] conditions) : this(power, new TargetFilter(), new Indefinite(), conditions)
        {
        }

        public PowerAttackerEffect(int power, CardFilter filter, Duration duration, params Condition[] conditions) : base(power, filter, duration, conditions.Union(new Condition[] { new Conditions.AttackingCreatureCondition(filter) }).ToArray())
        {
        }
    }
}
