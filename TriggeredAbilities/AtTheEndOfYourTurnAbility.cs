using Engine.Abilities;
using Interfaces;

namespace TriggeredAbilities;

public class AtTheEndOfYourTurnAbility : TriggeredAbility
{
    public AtTheEndOfYourTurnAbility(IOneShotEffect effect) : base(effect)
    {
    }

    public AtTheEndOfYourTurnAbility(AtTheEndOfYourTurnAbility ability) : base(ability)
    {
    }

    public override bool CanTrigger(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
        // return gameEvent is PhaseBegunEvent e && e.Phase.Type == PhaseOrStep.EndOfTurn && game.Turns.Single(
        //     x => x.Id == e.Turn.Id).ActivePlayer == Controller && CheckInterveningIfClause(game);
    }

    public override IAbility Copy()
    {
        return new AtTheEndOfYourTurnAbility(this);
    }

    public override string ToString()
    {
        return $"At the end of your turn, {GetEffectText()}";
    }
}
