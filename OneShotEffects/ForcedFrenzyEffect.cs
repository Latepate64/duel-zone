using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Each of your opponent's creatures gets "This creature attacks if able" until
/// the start of your next turn.
/// </summary>
public sealed class ForcedFrenzyEffect : OneShotEffect
{
    private readonly IContinuousEffectWithGameFactory factory;

    public ForcedFrenzyEffect(IContinuousEffectWithGameFactory factory)
    {
        this.factory = factory;
    }

    public ForcedFrenzyEffect(ForcedFrenzyEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            factory.Create(game, Controller));
    }

    public override IOneShotEffect Copy()
    {
        return new ForcedFrenzyEffect(this);
    }
}
