using Interfaces;

namespace OneShotEffects;

public sealed class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect
    : OneShotEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;
    private readonly IContinuousEffectFactory factory;

    public EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        IAbility ability,
        ICardFilter filter,
        IContinuousEffectFactory factory) : base()
    {
        this.ability = ability;
        this.filter = filter;
        this.factory = factory;
    }

    public EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect effect) : base(
            effect)
    {
        ability = effect.ability.Copy();
        filter = effect.filter.Copy();
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(
            Applier,
            filter);
        game.AddContinuousEffects(
            Ability,
            factory.Create(ability, creatures));
    }

    public override IOneShotEffect Copy()
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(this);
    }
}
