using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class ThisCreatureGetsAbilityEffect : OneShotEffect
{
    private readonly IAbility ability;
    private readonly IContinuousEffectWithAbilitiesAndCreaturesFactory factory;
    private readonly IDuration duration;

    public ThisCreatureGetsAbilityEffect(
        IContinuousEffectWithAbilitiesAndCreaturesFactory factory,
        IAbility ability,
        IDuration duration) : base()
    {
        this.ability = ability;
        this.factory = factory;
        this.duration = duration;
    }

    public ThisCreatureGetsAbilityEffect(
        ThisCreatureGetsAbilityEffect effect) : base(effect)
    {
        ability = effect.ability.Copy();
        factory = effect.factory;
        duration = effect.duration.Copy();
    }

    public override IOneShotEffect Copy()
    {
        return new ThisCreatureGetsAbilityEffect(this);
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create([ability], (ICreature)Source));
    }
}
