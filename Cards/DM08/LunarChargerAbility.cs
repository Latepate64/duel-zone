using Engine.Abilities;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Cards.DM08;

public sealed class LunarChargerAbility : LinkedTriggeredAbility
{
    private readonly IEnumerable<ICreature> _cards;
    private readonly Guid _turnId;

    public LunarChargerAbility(IEnumerable<ICreature> cards, Guid turnId)
    {
        _cards = cards;
        _turnId = turnId;
    }

    public LunarChargerAbility(LunarChargerAbility ability) : base(ability)
    {
        _cards = ability._cards;
        _turnId = ability._turnId;
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && e.Turn.Id == _turnId;
    }

    public override IAbility Copy()
    {
        return new LunarChargerAbility(this);
    }

    public override void Resolve(IGame game)
    {
        var cards = Controller.ChooseAnyNumberOfCards(_cards, "Choose which creatures to untap.");
        Controller.Untap(game, [.. cards]);
    }

    public override string ToString()
    {
        return $"At the end of the turn, you may untap ${_cards}.";
    }

    public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
    {
        return new LunarChargerAbility(this);
    }
}
