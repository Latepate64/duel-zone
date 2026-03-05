namespace Interfaces.Choices;

public interface INumberChoice : IChoice
{
    int? Choice { get; set; }
    int Min { get; }
    int? Max { get; }
}
