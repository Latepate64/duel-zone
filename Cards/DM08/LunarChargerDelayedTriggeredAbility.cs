using Engine.Abilities;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Cards.DM08;

public class LunarChargerDelayedTriggeredAbility : DelayedTriggeredAbility
{
    public LunarChargerDelayedTriggeredAbility(LunarChargerDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public LunarChargerDelayedTriggeredAbility(IAbility source, IEnumerable<ICreature> cards, Guid turnId) : base(
        new LunarChargerAbility(cards, turnId), source.Source, source.Controller, true)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new LunarChargerDelayedTriggeredAbility(this);
    }
}
