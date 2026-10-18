using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect : OneShotEffect
{
    private readonly IAbility[] abilities;
    private readonly ICardFilter filter;
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory;

    internal EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        params IAbility[] abilities
        ) : base()
    {
        this.abilities = abilities;
        this.filter = filter;
        this.effectFactory = effectFactory;
    }

    public EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect effect) : base(
            effect)
    {
        abilities = effect.abilities;
        filter = effect.filter;
        effectFactory = effect.effectFactory;
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        var effect = effectFactory.Create(abilities, [.. creatures]);
        game.AddContinuousEffects(Ability, effect);
    }

    public override IOneShotEffect Copy()
    {
        return new EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffect(this);
    }
}
