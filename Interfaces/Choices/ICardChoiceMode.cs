namespace Interfaces.Choices;

public interface ICardChoiceMode<T> where T : ICard
{
    bool CanBeChosenAutomatically(IEnumerable<T> cards);
    IEnumerable<T> ChooseAutomatically(IEnumerable<T> choosableCards);
    bool IsValid(IEnumerable<T> chosenCards);
}
