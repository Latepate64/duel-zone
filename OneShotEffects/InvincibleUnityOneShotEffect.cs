using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class InvincibleUnityOneShotEffect : OneShotEffect
{
    private readonly IAbilityAddingContinuousEffectFactory factory;
    private readonly ICardFilter filter;
    private readonly IAbility ability;

    public InvincibleUnityOneShotEffect(
        IAbilityAddingContinuousEffectFactory factory, ICardFilter filter, IAbility ability)
    {
        this.factory = factory;
        this.filter = filter;
        this.ability = ability;
    }

    private InvincibleUnityOneShotEffect(InvincibleUnityOneShotEffect effect) : base(effect)
    {
        factory = effect.factory;
        filter = effect.filter.Copy();
        ability = effect.ability.Copy();
    }

    public override void Apply(IGame game)
    {
        var creatures = game.BattleZone.GetCreaturesControlledByPlayer(Applier, filter);
        game.AddContinuousEffects(
            Ability,
            factory.Create(ability, [.. creatures]));
    }

    public override IOneShotEffect Copy()
    {
        return new InvincibleUnityOneShotEffect(this);
    }
}
