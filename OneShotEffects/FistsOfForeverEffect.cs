using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose one of your creatures in the battle zone. Whenever that creature wins, untap it.
/// </summary>
public sealed class FistsOfForeverEffect : OneShotEffect
{
    private readonly IDelayedTriggeredAbilityFactory delayedFactory;
    private readonly ITriggeredAbilityWithCreatureFactory triggerFactory;
    private readonly IDuration? duration;

    public FistsOfForeverEffect(
        IDelayedTriggeredAbilityFactory delayedFactory,
        ITriggeredAbilityWithCreatureFactory triggerFactory,
        IDuration? duration)
    {
        this.delayedFactory = delayedFactory;
        this.triggerFactory = triggerFactory;
        this.duration = duration;
    }

    private FistsOfForeverEffect(FistsOfForeverEffect effect) : base(effect)
    {
        delayedFactory = effect.delayedFactory;
        triggerFactory = effect.triggerFactory;
        duration = effect.duration?.Copy();
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseControlledCreature(game, ToString());
        game.AddDelayedTriggeredAbility(
            delayedFactory.Create(
                triggerFactory.Create(
                    creature),
                Ability,
                duration));
    }

    public override IOneShotEffect Copy()
    {
        return new FistsOfForeverEffect(this);
    }
}
