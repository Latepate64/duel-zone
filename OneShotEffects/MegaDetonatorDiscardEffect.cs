using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Discard any number of cards from your hand. Then choose the same number of
/// your creatures in the battle zone. Each of those creatures gets "double
/// breaker" until the end of the turn.
/// </summary>
public sealed class MegaDetonatorDiscardEffect : OneShotEffect
{
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly IAbility ability;

    internal MegaDetonatorDiscardEffect(
        IAbilityAddingContinuousEffectFactory factory, IAbility ability)
    {
        this.factory = factory;
        this.ability = ability;
    }

    private MegaDetonatorDiscardEffect(MegaDetonatorDiscardEffect effect) : base(effect)
    {
        factory = effect.factory;
        ability = effect.ability;
    }

    public override void Apply(IGame game)
    {
        var amount = Controller.DiscardAnyNumberOfCards(game, Ability);
        var creatures = Controller.ChooseControlledCreatures(
            game, ToString(), amount);
        game.AddContinuousEffects(
            Ability,
            factory.Create(ability, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new MegaDetonatorDiscardEffect(this);
    }
}
