using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class VreemahFreakyMojoTotemOneShotEffect : OneShotEffect
{
    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new VreemahFreakyMojoTotemContinuousEffect());
    }

    public override IOneShotEffect Copy()
    {
        return new VreemahFreakyMojoTotemOneShotEffect();
    }

    public override string ToString()
    {
        return "Each Beast Folk in the battle zone gets +2000 power and \"double breaker\" until the end of the turn.";
    }
}
