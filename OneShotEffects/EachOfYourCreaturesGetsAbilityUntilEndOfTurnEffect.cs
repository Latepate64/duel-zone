using Interfaces;

namespace OneShotEffects;

public sealed class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect : OneShotEffect
{
    private readonly IAbility ability;
    private readonly ICardFilter filter;
    private readonly IAbilityAddingContinuousEffectFactory effectFactory;

    internal EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        IAbility ability,
        ICardFilter filter,
        IAbilityAddingContinuousEffectFactory effectFactory) : base()
    {
        this.ability = ability;
        this.filter = filter;
        this.effectFactory = effectFactory;
    }

    public EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect effect) : base(
            effect)
    {
        ability = effect.ability;
        filter = effect.filter;
        effectFactory = effect.effectFactory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        var effect = effectFactory.Create(ability, [.. creatures]);
        game.AddContinuousEffects(Ability, effect);
    }

    public override IOneShotEffect Copy()
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(this);
    }
}
