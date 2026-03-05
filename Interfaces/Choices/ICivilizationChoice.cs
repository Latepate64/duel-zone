namespace Interfaces.Choices;

public interface ICivilizationChoice : IChoice
{
    Civilization? Choice { get; set; }
    Civilization[] Excluded { get; }
}
