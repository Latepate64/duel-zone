namespace Interfaces.Choices;

public interface IRaceChoice : IChoice
{
    Race? Choice { get; set; }
    IEnumerable<Race> Excluded { get; set; }
}
