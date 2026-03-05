using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class DiamondCutterOneShotEffect : OneShotEffect
{
    public DiamondCutterOneShotEffect()
    {
    }

    public DiamondCutterOneShotEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new DiamondCutterContinuousEffect(Ability.Controller.Id));
    }

    public override IOneShotEffect Copy()
    {
        return new DiamondCutterOneShotEffect(this);
    }

    public override string ToString()
    {
        return "This turn, ignore any effects that would prevent your creatures from attacking your opponent.";
    }
}
