using Interfaces;

namespace ContinuousEffects;

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
