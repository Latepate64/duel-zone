using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class EstolVizierOfAquaEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        var controller = Controller;
        controller.PutFromTopOfDeckIntoShieldZone(1, game, Ability);
        controller.LookAtOneOfOpponentsShields(game, Ability);
    }

    public override IOneShotEffect Copy()
    {
        return new EstolVizierOfAquaEffect();
    }

    public override string ToString()
    {
        return "Add the top card of your deck to your shields face down. Then look at one of your opponent's shields.";
    }
}
