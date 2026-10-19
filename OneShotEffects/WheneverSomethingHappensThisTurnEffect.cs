using Interfaces;

namespace OneShotEffects;

public sealed class WheneverSomethingHappensThisTurnEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityFactory delayedTriggeredAbilityFactory;
    private readonly ITriggeredAbility triggeredAbility;

    public WheneverSomethingHappensThisTurnEffect(
        IDelayedTriggeredAbilityFactory delayedTriggeredAbilityFactory,
        ITriggeredAbility triggeredAbility)
    {
        this.delayedTriggeredAbilityFactory = delayedTriggeredAbilityFactory;
        this.triggeredAbility = triggeredAbility;
    }

    private WheneverSomethingHappensThisTurnEffect(
        WheneverSomethingHappensThisTurnEffect effect) : base(effect)
    {
        delayedTriggeredAbilityFactory = effect.delayedTriggeredAbilityFactory;
        triggeredAbility = (ITriggeredAbility)effect.triggeredAbility.Copy();
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            delayedTriggeredAbilityFactory.Create(
                triggeredAbility,
                Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new WheneverSomethingHappensThisTurnEffect(this);
    }
}
