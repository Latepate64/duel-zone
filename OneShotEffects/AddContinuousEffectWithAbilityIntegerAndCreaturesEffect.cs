using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class AddContinuousEffectWithAbilityIntegerAndCreaturesEffect : OneShotEffect
{
    private readonly IContinuousEffectWithAbilityIntegerAndCreaturesFactory factory;
    private readonly ICardFilter filter;
    private readonly int power;
    private readonly IAbility ability;
    private readonly IDuration duration;

    public AddContinuousEffectWithAbilityIntegerAndCreaturesEffect(
        IContinuousEffectWithAbilityIntegerAndCreaturesFactory factory,
        ICardFilter filter,
        int power,
        IAbility ability,
        IDuration duration)
    {
        this.factory = factory;
        this.filter = filter;
        this.power = power;
        this.ability = ability;
        this.duration = duration;
    }

    private AddContinuousEffectWithAbilityIntegerAndCreaturesEffect(
        AddContinuousEffectWithAbilityIntegerAndCreaturesEffect effect) : base(effect)
    {
        factory = effect.factory;
        filter = effect.filter.Copy();
        power = effect.power;
        ability = effect.ability.Copy();
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(ability, power, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new AddContinuousEffectWithAbilityIntegerAndCreaturesEffect(this);
    }
}
