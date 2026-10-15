using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your creatures in the battle zone. Whenever that creature wins
/// a battle this turn, untap it.
/// </summary>
public sealed class FistsOfForeverEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityFactory delayedFactory;
    private readonly ITriggeredAbilityWithCreatureFactory triggerFactory;

    public FistsOfForeverEffect(
        IDelayedTriggeredAbilityFactory delayedFactory,
        ITriggeredAbilityWithCreatureFactory triggerFactory)
    {
        this.delayedFactory = delayedFactory;
        this.triggerFactory = triggerFactory;
    }

    private FistsOfForeverEffect(FistsOfForeverEffect effect) : base(effect)
    {
        delayedFactory = effect.delayedFactory;
        triggerFactory = effect.triggerFactory;
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseControlledCreature(game, ToString());
        game.AddDelayedTriggeredAbility(
            delayedFactory.Create(
                triggerFactory.Create(
                    creature),
                Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new FistsOfForeverEffect(this);
    }
}
