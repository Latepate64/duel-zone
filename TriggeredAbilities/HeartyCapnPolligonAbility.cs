using OneShotEffects;
using Interfaces;

namespace TriggeredAbilities;

public sealed class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
{
    public HeartyCapnPolligonAbility() : base(new HeartyCapnPolligonEffect())
    {
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        // if this creature broke any shields that turn
        throw new NotImplementedException();
        // return game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Any(x => x.Attacker == Source);
    }
}
