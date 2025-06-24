using Interfaces;
using Interfaces.Choices;

namespace Engine.Choices;

public sealed class NumberChoice : Choice, INumberChoice
{
    public int? Choice { get; set; }
    public int Min { get; }

    public int? Max { get; }

    public NumberChoice(NumberChoice choice) : base(choice)
    {
        Choice = choice.Choice;
        Min = choice.Min;
        Max = choice.Max;
    }

    public NumberChoice(IPlayer maker, string description, int min, int? max) : base(maker, description)
    {
        Min = min;
        Max = max;
    }

    public override bool IsValid()
    {
        return Choice.HasValue && Choice >= Min && (Max == null || Choice <= Max);
    }
}
