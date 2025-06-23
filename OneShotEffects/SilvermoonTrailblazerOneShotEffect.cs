using ContinuousEffects;
using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SilvermoonTrailblazerOneShotEffect : OneShotEffect
{
    public SilvermoonTrailblazerOneShotEffect()
    {
    }

    public SilvermoonTrailblazerOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new SilvermoonTrailblazerContinuousEffect(
            Controller.ChooseRace(ToString())));
    }

    public override IOneShotEffect Copy()
    {
        return new SilvermoonTrailblazerOneShotEffect(this);
    }

    public override string ToString()
    {
        return "Choose a race. Creatures of that race can't be blocked by creatures that have power 3000 or less this turn.";
    }
}
