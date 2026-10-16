using Interfaces;

namespace OneShotEffects;

public sealed class AfterBattleEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityWithEffectAndSourceFactory factory;
    private readonly IOneShotEffect effect;

    public AfterBattleEffect(
        IDelayedTriggeredAbilityWithEffectAndSourceFactory factory,
        IOneShotEffect effect)
    {
        this.factory = factory;
        this.effect = effect;
    }

    public AfterBattleEffect(
        AfterBattleEffect effect) : base(effect)
    {
        factory = effect.factory;
        this.effect = effect.effect;
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            factory.Create(
                effect,
                Ability));
            
    }

    public override IOneShotEffect Copy()
    {
        return new AfterBattleEffect(this);
    }
}
