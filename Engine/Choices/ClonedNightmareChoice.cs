using Engine.Choices;
using Interfaces;

namespace Engine.Choices;

public sealed class ClonedNightmareChoice : NumberChoice
{
    private readonly int _max;

    public ClonedNightmareChoice(ClonedNightmareChoice choice) : base(choice)
    {
        _max = choice._max;
    }

    public ClonedNightmareChoice(IPlayer maker, string description, int max) : base(maker, description)
    {
        _max = max;
    }

    public override bool IsValid()
    {
        return base.IsValid() && Choice >= 1 && Choice <= _max;
    }
}
