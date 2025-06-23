using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class WhiskingWhirlwindEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        throw new NotImplementedException();
        // game.AddDelayedTriggeredAbility(new AtTheEndOfTheTurnDelayedTriggeredAbility(
        //     Ability, game.CurrentTurn.Id, new WhiskingWhirlwindUntapEffect()));
    }

    public override IOneShotEffect Copy()
    {
        return new WhiskingWhirlwindEffect();
    }

    public override string ToString()
    {
        return "At the end of the turn, untap all your creatures in the battle zone.";
    }
}
