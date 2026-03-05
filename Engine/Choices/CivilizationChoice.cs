using System.Linq;
using Interfaces;
using Interfaces.Choices;

namespace Engine.Choices;

public sealed class CivilizationChoice : Choice, ICivilizationChoice
{
    public CivilizationChoice(CivilizationChoice choice) : base(choice)
    {
        Choice = choice.Choice;
        Excluded = choice.Excluded;
    }

    public CivilizationChoice(Player maker, string description, params Civilization[] excluded) : base(maker, description)
    {
        Excluded = excluded;
    }

    public Civilization? Choice { get; set; }
    public Civilization[] Excluded { get; }

    public override bool IsValid()
    {
        return Choice.HasValue && !Excluded.Contains(Choice.Value);
    }
}
