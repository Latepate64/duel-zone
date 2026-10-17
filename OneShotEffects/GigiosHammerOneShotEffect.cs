using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class RaceAffectingContinuousEffectAddingEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceFactory factory;

    public RaceAffectingContinuousEffectAddingEffect(
        IContinuousEffectWithRaceFactory factory)
    {
        this.factory = factory;
    }

    public RaceAffectingContinuousEffectAddingEffect(
        RaceAffectingContinuousEffectAddingEffect effect) : base(effect)
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
        return new RaceAffectingContinuousEffectAddingEffect(this);
    }
}
