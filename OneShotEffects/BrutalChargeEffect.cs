using Interfaces;

namespace OneShotEffects;

/// <summary>
/// At the end of this turn, search your deck. For each of your opponent's
/// shields your creatures broke this turn, you may take a creature from your
/// deck, show it to your opponent, and put it into your hand. Then shuffle your
/// deck.
/// </summary>
public sealed class BrutalChargeEffect : OneShotEffect
{
    private readonly IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory factory;

    public BrutalChargeEffect(
        IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory factory)
    {
        this.factory = factory;
    }

    public BrutalChargeEffect(BrutalChargeEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        game.AddDelayedTriggeredAbility(
            factory.Create(
                Ability,
                Guid.NewGuid(),
                new BrutalChargeDelayedEffect()));
    }

    public override IOneShotEffect Copy()
    {
        return new BrutalChargeEffect(this);
    }
}
