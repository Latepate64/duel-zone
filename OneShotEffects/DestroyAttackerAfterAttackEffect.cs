using Interfaces;

namespace OneShotEffects;

public sealed class DestroyAttackerAfterAttackEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityWithEffectAndSourceFactory factory;

    public DestroyAttackerAfterAttackEffect(
        IDelayedTriggeredAbilityWithEffectAndSourceFactory factory)
    {
        this.factory = factory;
    }

    public DestroyAttackerAfterAttackEffect(
        DestroyAttackerAfterAttackEffect effect) : base(effect)
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
        return new DestroyAttackerAfterAttackEffect(this);
    }
}
