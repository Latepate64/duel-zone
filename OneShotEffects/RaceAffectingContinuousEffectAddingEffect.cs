using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class RaceAffectingContinuousEffectAddingEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceFactory factory;
    private readonly IDuration duration;

    public RaceAffectingContinuousEffectAddingEffect(
        IContinuousEffectWithRaceFactory factory,
        IDuration duration)
    {
        this.factory = factory;
        this.duration = duration;
    }

    public RaceAffectingContinuousEffectAddingEffect(
        RaceAffectingContinuousEffectAddingEffect effect) : base(effect)
    {
        factory = effect.factory;
        duration = effect.duration;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(
            Ability,
            duration,
            factory.Create(race));
    }

    public override IOneShotEffect Copy()
    {
        return new RaceAffectingContinuousEffectAddingEffect(this);
    }
}
