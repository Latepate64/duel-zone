namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    /// <summary>
    /// 603.1. Triggered abilities have a trigger condition and an effect. They are written as “[When/Whenever/At] [trigger condition or event], [effect]. [Instructions (if any).]”
    /// </summary>
    public abstract class TriggeredAbility : NonStaticAbility
    {
        public TriggerCondition TriggerCondition { get; set; }

        protected TriggeredAbility(TriggerCondition triggerCondition, System.Guid source) : base(source)
        {
            TriggerCondition = triggerCondition;
        }

        protected TriggeredAbility(TriggeredAbility ability) : base(ability)
        {
            TriggerCondition = ability.TriggerCondition.Copy();
        }
    }

    internal class DelayedTriggeredAbility
    {
        internal TriggeredAbility TriggeredAbility { get; }
        internal Effects.Periods.Period Period { get; }

        internal DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Effects.Periods.Period period, System.Guid controller)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Controller = controller;
            Period = period;
        }

        internal DelayedTriggeredAbility(DelayedTriggeredAbility ability)
        {
            TriggeredAbility = ability.TriggeredAbility.Copy() as TriggeredAbility;
            Period = ability.Period.Copy();
        }
    }
}
