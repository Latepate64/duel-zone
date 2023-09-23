using System;
using Cards.TriggeredAbilities;

namespace Engine.Abilities
{
    public class AtTheEndOfTheTurnDelayedTriggeredAbility : DelayedTriggeredAbility
    {
        public AtTheEndOfTheTurnDelayedTriggeredAbility(IAbility ability, Guid turn, OneShotEffect effect) : base(new AtTheEndOfTurnAbility(turn, effect), ability.Source, ability.Controller, true)
        {
        }

        public AtTheEndOfTheTurnDelayedTriggeredAbility(AtTheEndOfTheTurnDelayedTriggeredAbility ability) : base(ability)
        {
        }

        public override DelayedTriggeredAbility Copy()
        {
            return new AtTheEndOfTheTurnDelayedTriggeredAbility(this);
        }
    }
}
