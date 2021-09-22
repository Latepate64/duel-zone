using DuelMastersModels.Cards;
using DuelMastersModels.Effects.OneShotEffects;
using System.Collections.Generic;

namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public abstract class TriggeredAbility : NonStaticAbility
    {
        public TriggerCondition TriggerCondition { get; set; }

        protected TriggeredAbility(TriggerCondition triggerCondition, Card source) : base(null, source)
        {
            TriggerCondition = triggerCondition;
        }

        protected TriggeredAbility(TriggerCondition triggerCondition, Queue<OneShotEffect> effects, Card source) : base(effects, source)
        {
            TriggerCondition = triggerCondition;
        }

        protected TriggeredAbility(TriggerCondition triggerCondition, OneShotEffect effect, Card source) : this(triggerCondition, new Queue<OneShotEffect>(), source)
        {
            Effects.Enqueue(effect);
        }
    }

    internal class DelayedTriggeredAbility
    {
        internal TriggeredAbility TriggeredAbility { get; }
        internal Effects.Periods.Period Period { get; }

        internal DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Effects.Periods.Period period)
        {
            TriggeredAbility = triggeredAbility;
            Period = period;
        }
    }
}
