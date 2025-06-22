using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public sealed class ImpossibleTunnelOneShotEffect : OneShotEffect
{
    public ImpossibleTunnelOneShotEffect()
    {
    }

    public ImpossibleTunnelOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new ImpossibleTunnelContinuousEffect(Controller.ChooseRace(ToString())));
    }

    public override IOneShotEffect Copy()
    {
        return new ImpossibleTunnelOneShotEffect(this);
    }

    public override string ToString()
    {
        return "Choose a race. Creatures of that race can't be blocked this turn.";
    }
}
