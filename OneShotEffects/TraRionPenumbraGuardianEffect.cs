using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a race. At the end of this turn, untap all creatures of that race in
/// the battle zone.
/// </summary>
public sealed class TraRionPenumbraGuardianEffect : OneShotEffect
{
    private readonly IRaceCreatureFilterFactory factory;
    private readonly IDelayedTriggeredAbility delayedTrigger;

    public TraRionPenumbraGuardianEffect(
        IRaceCreatureFilterFactory factory,
        IDelayedTriggeredAbility delayedTrigger)
    {
        this.factory = factory;
        this.delayedTrigger = delayedTrigger;
    }

    public TraRionPenumbraGuardianEffect(
        TraRionPenumbraGuardianEffect effect) : base(effect)
    {
        factory = effect.factory;
        delayedTrigger = effect.delayedTrigger.Copy();
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        var raceFilter = factory.Create(race);
        var effect = new UntapAreaOfEffect(raceFilter, SelectionRange.AllCards);
        var newDelayedTrigger = delayedTrigger.CreateNew(
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
