using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Discard any number of cards from your hand. Then choose the same number of
/// your creatures in the battle zone. Each of those creatures gets "double
/// breaker" until the end of the turn.
/// </summary>
public sealed class MegaDetonatorDiscardEffect : OneShotEffect
{
    private readonly IContinuousEffectFactory factory;

    public MegaDetonatorDiscardEffect(IContinuousEffectFactory factory)
    {
        this.factory = factory;
    }

    public MegaDetonatorDiscardEffect(
        MegaDetonatorDiscardEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var amount = Controller.DiscardAnyNumberOfCards(game, Ability);
        var creatures = Controller.ChooseControlledCreatures(
            game, ToString(), amount);
        game.AddContinuousEffects(
            Ability,
            factory.Create([.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new MegaDetonatorDiscardEffect(this);
    }
}
