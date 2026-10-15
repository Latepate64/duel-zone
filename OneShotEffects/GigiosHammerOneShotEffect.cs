using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Choose a race. Each creature of that race attacks this turn if able and gets
/// "power attacker +4000" until the end of the turn.
/// </summary>
public sealed class GigiosHammerOneShotEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceFactory factory;

    public GigiosHammerOneShotEffect(IContinuousEffectWithRaceFactory factory)
    {
        this.factory = factory;
    }

    public GigiosHammerOneShotEffect(
        GigiosHammerOneShotEffect effect) : base(effect)
    {
        factory = effect.factory;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(
            Ability,
            factory.Create(race));
    }

    public override IOneShotEffect Copy()
    {
        return new GigiosHammerOneShotEffect(this);
    }
}
