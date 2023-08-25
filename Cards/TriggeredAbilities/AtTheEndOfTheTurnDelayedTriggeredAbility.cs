using System;
using Cards.TriggeredAbilities;

namespace Engine.Abilities
{
    public class AtTheEndOfTheTurnDelayedTriggeredAbility : DelayedTriggeredAbility
    {
        public AtTheEndOfTheTurnDelayedTriggeredAbility(ICard source, IPlayer owner, Guid turn, OneShotEffect effect) : base(new AtTheEndOfTurnAbility(turn, effect), source, owner, true)
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
