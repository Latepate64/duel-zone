using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;

namespace TriggeredAbilities;

public sealed class KachuaAbility : LinkedTriggeredAbility
{
    private readonly ICreature _card;
    private readonly Guid _turnId;

    public KachuaAbility(ICreature card, Guid turnId)
    {
        _card = card;
        _turnId = turnId;
    }

    public KachuaAbility(KachuaAbility ability) : base(ability)
    {
        _card = ability._card;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && e.Turn.Id == _turnId;
    }

    public override IAbility Copy()
    {
        return new KachuaAbility(this);
    }

    public override void Resolve(IGame game)
    {
        game.Destroy(this, _card);
    }

    public override string ToString()
    {
        return $"Destroy {_card}.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return new KachuaAbility(this);
    }
}
