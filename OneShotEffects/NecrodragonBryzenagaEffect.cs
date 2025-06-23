using Interfaces;

namespace OneShotEffects;

public sealed class NecrodragonBryzenagaEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.PutFromShieldZoneToHand(Controller.ShieldZone.Cards, true, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new NecrodragonBryzenagaEffect();
    }

    public override string ToString()
    {
        return "Put all your shields into your hand.";
    }
}
