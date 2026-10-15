using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class ContinuousEffectAddingEffect : OneShotEffect
{
    private readonly IContinuousEffect continuousEffect;

    public ContinuousEffectAddingEffect(
        IContinuousEffect continuousEffect) : base()
    {
        this.continuousEffect = continuousEffect;
    }

    public ContinuousEffectAddingEffect(
        ContinuousEffectAddingEffect effect) : base(effect)
    {
        continuousEffect = effect.continuousEffect.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, continuousEffect);
    }

    public override IOneShotEffect Copy()
    {
        return new ContinuousEffectAddingEffect(this);
    }
}
