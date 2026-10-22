using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class ContinuousEffectAddingEffect : OneShotEffect
{
    private readonly IContinuousEffect continuousEffect;
    private readonly IDuration duration;

    public ContinuousEffectAddingEffect(
        IContinuousEffect continuousEffect,
        IDuration duration) : base()
    {
        this.continuousEffect = continuousEffect;
        this.duration = duration;
    }

    public ContinuousEffectAddingEffect(
        ContinuousEffectAddingEffect effect) : base(effect)
    {
        continuousEffect = effect.continuousEffect.Copy();
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, duration, continuousEffect);
    }

    public override IOneShotEffect Copy()
    {
        return new ContinuousEffectAddingEffect(this);
    }
}
