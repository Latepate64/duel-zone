using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

/// <summary>
/// Until the end of the turn, each of your creatures in the battle zone gets +x
/// power and "double breaker." Whenever any of those creatures battles this
/// turn, destroy it after the battle.
/// </summary>
public sealed class BattleshipMutantEffect : OneShotEffect
{
    private readonly ICardFilter filter;
    private readonly IDelayedTriggeredAbilityFactory delayedTriggerFactory;
    private readonly ITriggeredAbilityFactory triggeredAbilityFactory;
    private readonly IContinuousEffect continuousEffect;
    private readonly IDuration duration;

    public BattleshipMutantEffect(
        IContinuousEffect continuousEffect,
        ICardFilter filter,
        IDelayedTriggeredAbilityFactory delayedTriggerFactory,
        ITriggeredAbilityFactory triggeredAbilityFactory,
        IDuration duration)
    {
        this.continuousEffect = continuousEffect;
        this.filter = filter;
        this.delayedTriggerFactory = delayedTriggerFactory;
        this.triggeredAbilityFactory = triggeredAbilityFactory;
        this.duration = duration;
    }

    public BattleshipMutantEffect(BattleshipMutantEffect effect) : base(effect)
    {
        continuousEffect = effect.continuousEffect.Copy();
        filter = effect.filter.Copy();
        delayedTriggerFactory = effect.delayedTriggerFactory;
        triggeredAbilityFactory = effect.triggeredAbilityFactory;
        duration = effect.duration.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            duration,
            continuousEffect);
        game.AddDelayedTriggeredAbility(
            delayedTriggerFactory.Create(
                triggeredAbilityFactory.Create(
                    game.BattleZone, Applier, filter),
                Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new BattleshipMutantEffect(this);
    }
}
