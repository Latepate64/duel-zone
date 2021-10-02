using System;

namespace DuelMastersModels.Abilities.Triggered
{
    internal class DelayedTriggeredAbility
    {
        internal TriggeredAbility TriggeredAbility { get; }
        internal Effects.Periods.Period Period { get; }

        internal DelayedTriggeredAbility(TriggeredAbility triggeredAbility, Effects.Periods.Period period, Guid source, Guid controller)
        {
            TriggeredAbility = triggeredAbility;
            TriggeredAbility.Source = source;
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
