using Interfaces;

namespace OneShotEffects;

public sealed class AtTheEndOfTurnEffect : OneShotEffect
{
    private readonly IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory factory;
    private readonly IOneShotEffect effect;

    public AtTheEndOfTurnEffect(
        IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory factory,
        IOneShotEffect effect)
    {
        this.factory = factory;
        this.effect = effect;
    }

    public AtTheEndOfTurnEffect(AtTheEndOfTurnEffect effect) : base(effect)
    {
        factory = effect.factory;
        this.effect = effect.effect;
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            factory.Create(
                Ability,
                Guid.NewGuid(),
                effect));
    }

    public override IOneShotEffect Copy()
    {
        return new AtTheEndOfTurnEffect(this);
    }
}
