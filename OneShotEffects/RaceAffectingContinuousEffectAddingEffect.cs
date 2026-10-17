using Interfaces;
using Interfaces.ContinuousEffects;

namespace OneShotEffects;

public sealed class RaceAffectingContinuousEffectAddingEffect : OneShotEffect
{
    private readonly IContinuousEffectWithRaceFactory effectFactory;

    public RaceAffectingContinuousEffectAddingEffect(IContinuousEffectWithRaceFactory factory)
    {
        this.effectFactory = factory;
    }

    public RaceAffectingContinuousEffectAddingEffect(
        RaceAffectingContinuousEffectAddingEffect effect) : base(effect)
    {
        effectFactory = effect.effectFactory;
    }

    public override void Apply(IGame game)
    {
        var race = Controller.ChooseRace(ToString());
        game.AddContinuousEffects(
            Ability,
            effectFactory.Create(race));
    }

    public override IOneShotEffect Copy()
    {
        return new RaceAffectingContinuousEffectAddingEffect(this);
    }
}
