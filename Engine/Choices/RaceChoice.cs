using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Choices;

namespace Engine.Choices;

public class RaceChoice : Choice, IRaceChoice
{
    public RaceChoice(IRaceChoice choice) : base(choice)
    {
        Choice = choice.Choice;
        Excluded = choice.Excluded;
    }

    public RaceChoice(IPlayer maker, string description, params Race[] excluded) : base(maker, description)
    {
        Excluded = excluded;
    }

    public Race? Choice { get; set; }
    public IEnumerable<Race> Excluded { get; set; }

    public override bool IsValid()
    {
        return Choice.HasValue && !Excluded.Contains(Choice.Value);
    }
}
