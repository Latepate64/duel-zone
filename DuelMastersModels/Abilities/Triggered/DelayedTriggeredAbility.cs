namespace DuelMastersModels.Abilities.Triggered
{
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
