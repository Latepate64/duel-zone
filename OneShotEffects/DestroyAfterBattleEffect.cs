using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Destroy it after the battle.
/// </summary>
public sealed class DestroyAfterBattleEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityWithEffectAndSourceFactory factory;

    public DestroyAfterBattleEffect(
        IDelayedTriggeredAbilityWithEffectAndSourceFactory factory)
    {
        this.factory = factory;
    }

    public DestroyAfterBattleEffect(
        DestroyAfterBattleEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            factory.Create(
                new DestroyThisCreatureEffect(),
                Ability));
            
    }

    public override IOneShotEffect Copy()
    {
        return new DestroyAfterBattleEffect(this);
    }
}
