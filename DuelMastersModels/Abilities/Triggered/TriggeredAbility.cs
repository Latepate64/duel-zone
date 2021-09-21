﻿using DuelMastersModels.Cards;
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

        public TriggeredAbility(TriggerCondition triggerCondition, Card source) : base(null, source)
        {
            TriggerCondition = triggerCondition;
        }

        public TriggeredAbility(TriggerCondition triggerCondition, Queue<OneShotEffect> effects, Card source) : base(effects, source)
        {
            TriggerCondition = triggerCondition;
        }

        public TriggeredAbility(TriggerCondition triggerCondition, OneShotEffect effect, Card source) : this(triggerCondition, new Queue<OneShotEffect>(), source) {
            Effects.Enqueue(effect);
        }

        /// <summary>
        /// 603.3. Once an ability has triggered, its controller puts it on the stack as an object that’s not a card the next time a player would receive priority.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public TriggeredAbility CreatePendingTriggeredAbility(Player controller, Card source)
        {
            // TODO: Rework
            return null;
            //return new TriggeredAbility(TriggerCondition, Effects) { Controller = controller, Source = source };
            /*
            var effects = new List<Effect>();
            foreach (var effect in Effects)
            {
                effects.Add(effect.DeepCopy());
            }
            return new TriggeredAbility(TriggerCondition, effects);*/
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
