namespace Interfaces.Choices;

public interface IBoundedCardChoiceMode<T> : ICardChoiceMode<T> where T : ICard
{
    int Min { get; }
    int Max { get; }
}
