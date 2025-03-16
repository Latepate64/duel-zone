namespace Engine.Choices;

public interface INumberChoice : IChoice
{
    int? Choice { get; set; }
}