using OneShotEffects;
using Engine.GameEvents;
using Interfaces;

namespace TriggeredAbilities;

public class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
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
