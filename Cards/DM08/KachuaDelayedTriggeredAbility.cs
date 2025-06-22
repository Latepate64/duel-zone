using Engine.Abilities;
using Interfaces;
using System;

namespace Cards.DM08;

public sealed class KachuaDelayedTriggeredAbility : DelayedTriggeredAbility
{
    public KachuaDelayedTriggeredAbility(KachuaDelayedTriggeredAbility ability) : base(ability)
    {
    }

    public KachuaDelayedTriggeredAbility(IAbility source, ICreature card, Guid turnId) : base(
        new KachuaAbility(card, turnId), source.Source, source.Controller, true)
    {
    }

    public override DelayedTriggeredAbility Copy()
    {
        return new KachuaDelayedTriggeredAbility(this);
    }
}
