using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class OptionalMadnessEffect : MadnessEffect
{
    public OptionalMadnessEffect()
    {
    }

    public OptionalMadnessEffect(OptionalMadnessEffect effect) : base(effect)
    {
    }

    public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
    {
        throw new NotImplementedException();
    }

    public override IContinuousEffect Copy()
    {
        return new OptionalMadnessEffect(this);
    }

    public override string ToString()
    {
        return "When this creature would be discarded from your hand during your opponent's turn, you may put it into the battle zone instead.";
    }
}
