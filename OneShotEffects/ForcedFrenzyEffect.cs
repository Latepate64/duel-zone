using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Each of your opponent's creatures gets "This creature attacks if able" until
/// the start of your next turn.
/// </summary>
public sealed class ForcedFrenzyEffect : OneShotEffect
{
    private readonly IContinuousEffectWithGameFactory factory;
    private readonly IDuration duration;

    public ForcedFrenzyEffect(IContinuousEffectWithGameFactory factory, IDuration duration)
    {
        this.factory = factory;
        this.duration = duration;
    }

    public ForcedFrenzyEffect(ForcedFrenzyEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(game, Controller));
    }

    public override IOneShotEffect Copy()
    {
        return new ForcedFrenzyEffect(this);
    }
}
