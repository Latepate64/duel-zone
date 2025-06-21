using OneShotEffects;
using Engine;
using Engine.GameEvents;

namespace TriggeredAbilities;

public class HeartyCapnPolligonAbility : AtTheEndOfYourTurnAbility
{
    public HeartyCapnPolligonAbility() : base(new HeartyCapnPolligonEffect())
    {
    }

    public override bool CheckInterveningIfClause(IGame game)
    {
        // if this creature broke any shields that turn
        return game.CurrentTurn.GameEvents.OfType<CreatureBreaksShieldsEvent>().Any(x => x.Attacker == Source);
    }
}
