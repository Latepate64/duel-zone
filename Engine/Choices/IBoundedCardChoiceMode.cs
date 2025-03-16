namespace Engine.Choices;

public interface IBoundedCardChoiceMode : ICardChoiceMode
{
    int Min { get; }
    int Max { get; }
}
