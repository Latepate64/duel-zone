using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect : OneShotEffect
{
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly IAbility ability;

    public DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(
        IAbilityAddingContinuousEffectFactory factory, IAbility ability)
    {
        this.factory = factory;
        this.ability = ability;
    }

    private DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(
        DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect effect) : base(effect)
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
        return new DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(this);
    }
}
