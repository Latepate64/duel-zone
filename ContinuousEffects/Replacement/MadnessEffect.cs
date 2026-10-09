using Interfaces;

namespace ContinuousEffects.Replacement;

public abstract class MadnessEffect : ReplacementEffect
{
    protected MadnessEffect()
    {
    }

    protected MadnessEffect(MadnessEffect effect) : base(effect)
    {
    }

    public override bool CanBeApplied(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }
}
