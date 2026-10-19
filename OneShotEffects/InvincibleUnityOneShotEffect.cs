using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class InvincibleUnityOneShotEffect : OneShotEffect
{
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly ICardFilter filter;
    private readonly IAbility ability;
    private readonly IDuration duration;

    public InvincibleUnityOneShotEffect(
        IAbilityAddingContinuousEffectFactory factory,
        ICardFilter filter,
        IAbility ability,
        IDuration duration)
    {
        this.factory = factory;
        this.filter = filter;
        this.ability = ability;
        this.duration = duration;
    }

    private InvincibleUnityOneShotEffect(InvincibleUnityOneShotEffect effect) : base(effect)
    {
        factory = effect.factory;
        filter = effect.filter.Copy();
        ability = effect.ability.Copy();
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(ability, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleUnityOneShotEffect(this);
    }
}
