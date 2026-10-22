using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class EachOfYourCreaturesGetsAbilityEffect : OneShotEffect
{
    private readonly IAbility[] abilities;
    private readonly ICardFilter filter;
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory;
    private readonly IDuration duration;

    internal EachOfYourCreaturesGetsAbilityEffect(
        ICardFilter filter,
        IContinuousEffectWithAbilitiesAndCreaturesFactory effectFactory,
        IDuration duration,
        params IAbility[] abilities
        ) : base()
    {
        this.abilities = abilities;
        this.filter = filter;
        this.effectFactory = effectFactory;
        this.duration = duration;
    }

    public EachOfYourCreaturesGetsAbilityEffect(
        EachOfYourCreaturesGetsAbilityEffect effect) : base(
            effect)
    {
        abilities = effect.abilities;
        filter = effect.filter;
        effectFactory = effect.effectFactory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        var effect = effectFactory.Create(abilities, [.. creatures]);
        game.AddContinuousEffects(Ability, duration, effect);
    }

    public override IOneShotEffect Copy()
    {
        return new EachOfYourCreaturesGetsAbilityEffect(this);
    }
}
