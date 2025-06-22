using Engine.Abilities;
using Interfaces;

namespace Cards.DM02;

public class RumbleGateOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new RumbleGateContinuousEffect(Ability.Controller.Id));
    }

    public override IOneShotEffect Copy()
    {
        return new RumbleGateOneShotEffect();
    }

    public override string ToString()
    {
        return "Each of your creatures in the battle zone that can attack creatures can attack untapped creatures this turn.";
    }
}
