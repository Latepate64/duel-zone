using Abilities;
using Engine.GameEvents;
using Engine.Steps;
using Interfaces;

namespace TriggeredAbilities;

public sealed class AtTheEndOfTurnAbility : TriggeredAbility
{
    public Guid Turn { get; }

    public AtTheEndOfTurnAbility(Guid turn, IOneShotEffect effect) : base(effect)
    {
        Turn = turn;
    }

    public AtTheEndOfTurnAbility(AtTheEndOfTurnAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && e.Turn.Id == Turn
            && CheckInterveningIfClause(game);
    }

    public override Ability Copy()
    {
        return new AtTheEndOfTurnAbility(this);
    }

    public override string ToString()
    {
        return $"At the end of that turn, {GetEffectText()}";
    }
}
