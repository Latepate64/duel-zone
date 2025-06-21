using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class TraRionPenumbraGuardianEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new AtTheEndOfTheTurnDelayedTriggeredAbility(
        //     Ability,
        //     game.CurrentTurn.Id,
        //     new TraRionPenumbraGuardianUntapEffect(Controller.ChooseRace(ToString()))));
    }

    public override IOneShotEffect Copy()
    {
        return new TraRionPenumbraGuardianEffect();
    }

    public override string ToString()
    {
        return "Choose a race. At the end of this turn, untap all creatures of that race in the battle zone.";
    }
}
