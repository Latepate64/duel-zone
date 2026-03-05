using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class BaraidTheExplorerEffect : OneShotEffect
{
    public BaraidTheExplorerEffect() : base()
    {
    }

    public override void Apply(IGame game)
    {
        game.AddContinuousEffects(Ability, new YourLightCreaturesCannotBeBlockedThisTurnEffect());
    }

    public override IOneShotEffect Copy()
    {
        return new BaraidTheExplorerEffect();
    }

    public override string ToString()
    {
        return "Your light creatures can't be blocked this turn.";
    }
}
