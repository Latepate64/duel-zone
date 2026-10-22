using Interfaces;

namespace OneShotEffects;

public sealed class WheneverSomethingHappensThisTurnEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityFactory delayedTriggeredAbilityFactory;
    private readonly ITriggeredAbility triggeredAbility;
    private readonly IDuration? duration;

    public WheneverSomethingHappensThisTurnEffect(
        IDelayedTriggeredAbilityFactory delayedTriggeredAbilityFactory,
        ITriggeredAbility triggeredAbility,
        IDuration? duration)
    {
        this.delayedTriggeredAbilityFactory = delayedTriggeredAbilityFactory;
        this.triggeredAbility = triggeredAbility;
        this.duration = duration;
    }

    private WheneverSomethingHappensThisTurnEffect(
        WheneverSomethingHappensThisTurnEffect effect) : base(effect)
    {
        delayedTriggeredAbilityFactory = effect.delayedTriggeredAbilityFactory;
        triggeredAbility = (ITriggeredAbility)effect.triggeredAbility.Copy();
        duration = effect.duration?.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            delayedTriggeredAbilityFactory.Create(
                triggeredAbility,
                Ability,
                duration));
    }

    public override IOneShotEffect Copy()
    {
        return new WheneverSomethingHappensThisTurnEffect(this);
    }
}
