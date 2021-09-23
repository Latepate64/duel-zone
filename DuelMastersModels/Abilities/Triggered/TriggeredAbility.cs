using DuelMastersModels.Cards;

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

        protected TriggeredAbility Copy(TriggeredAbility ability)
        {
            ability.Controller = Controller.Copy();
            //ability.Effects
            ability.TriggerCondition = TriggerCondition.Copy();
            return ability;
        }
    }

    internal class DelayedTriggeredAbility : ICopyable<DelayedTriggeredAbility>
    {
        internal TriggeredAbility TriggeredAbility { get; }
        internal Effects.Periods.Period Period { get; }

        internal DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Effects.Periods.Period period)
        {
            TriggeredAbility = triggeredAbility;
            Period = period;
        }

        public DelayedTriggeredAbility Copy()
        {
            return new DelayedTriggeredAbility(TriggeredAbility.Copy() as TriggeredAbility, Period.Copy());
        }
    }
}
