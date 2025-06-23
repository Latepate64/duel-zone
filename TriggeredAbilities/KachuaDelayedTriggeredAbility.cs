using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

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
