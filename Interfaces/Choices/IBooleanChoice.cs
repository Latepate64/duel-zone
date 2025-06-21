namespace Interfaces.Choices;

public interface IBooleanChoice : IChoice
{
    bool? Choice { get; set; }
}
