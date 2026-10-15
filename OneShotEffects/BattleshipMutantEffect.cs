using Interfaces;
using ContinuousEffects.AbilityAddingPowerModifying;

namespace OneShotEffects;

/// <summary>
/// Until the end of the turn, each of your creatures in the battle zone gets +x
/// power and "double breaker." Whenever any of those creatures battles this
/// turn, destroy it after the battle.
/// </summary>
public sealed class BattleshipMutantEffect : OneShotEffect
{
    private readonly int power;
    private readonly ICardFilter filter;
    private readonly IDelayedTriggeredAbilityFactory delayedTriggerFactory;
    private readonly ITriggeredAbilityFactory triggeredAbilityFactory;

    public BattleshipMutantEffect(
        int power,
        ICardFilter filter,
        IDelayedTriggeredAbilityFactory delayedTriggerFactory,
        ITriggeredAbilityFactory triggeredAbilityFactory)
    {
        this.power = power;
        this.filter = filter;
        this.delayedTriggerFactory = delayedTriggerFactory;
        this.triggeredAbilityFactory = triggeredAbilityFactory;
    }

    public BattleshipMutantEffect(BattleshipMutantEffect effect) : base(effect)
    {
        filter = effect.filter.Copy();
        delayedTriggerFactory = effect.delayedTriggerFactory;
        triggeredAbilityFactory = effect.triggeredAbilityFactory;
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(
            Ability,
            new BattleshipMutantContinuousEffect(power, filter));
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
