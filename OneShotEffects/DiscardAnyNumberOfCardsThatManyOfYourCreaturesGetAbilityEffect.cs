using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect : OneShotEffect
{
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly IAbility ability;
    private readonly IDuration duration;

    public DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(
        IAbilityAddingContinuousEffectFactory factory, IAbility ability, IDuration duration)
    {
        this.factory = factory;
        this.ability = ability;
        this.duration = duration;
    }

    private DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(
        DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect effect) : base(effect)
    {
        factory = effect.factory;
        ability = effect.ability.Copy();
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var amount = Controller.DiscardAnyNumberOfCards(game, Ability);
        var creatures = Controller.ChooseControlledCreatures(
            game, ToString(), amount);
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(ability, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new DiscardAnyNumberOfCardsThatManyOfYourCreaturesGetAbilityEffect(this);
    }
}
