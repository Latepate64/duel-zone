using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a race. At the end of this turn, untap all creatures of that race in
/// the battle zone.
/// </summary>
public sealed class TraRionPenumbraGuardianEffect : OneShotEffect
{
    private readonly IRaceCreatureFilterFactory factory;
    private readonly IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory delayedTriggerFactory;

    public TraRionPenumbraGuardianEffect(
        IRaceCreatureFilterFactory factory,
        IAtTheEndOfTheTurnDelayedTriggeredAbilityFactory delayedTriggerFactory)
    {
        this.factory = factory;
        this.delayedTriggerFactory = delayedTriggerFactory;
    }

    public TraRionPenumbraGuardianEffect(
        TraRionPenumbraGuardianEffect effect) : base(effect)
    {
        factory = effect.factory;
        delayedTriggerFactory = effect.delayedTriggerFactory;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var raceFilter = factory.Create(race);
        var effect = new UntapAreaOfEffect(raceFilter, SelectionRange.AllCards);
        var newDelayedTrigger = delayedTriggerFactory.Create(
            Ability,
            turn: Guid.NewGuid(),
            effect);
        game.AddDelayedTriggeredAbility(newDelayedTrigger);
    }

    public override IOneShotEffect Copy()
    {
        return new TraRionPenumbraGuardianEffect(this);
    }
}
