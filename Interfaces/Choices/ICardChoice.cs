namespace Interfaces.Choices;

public interface ICardChoice<T> : IChoice where T : ICard
{
    bool CanBeChosenAutomatically { get; }
    IEnumerable<T> Cards { get; set; }
    IEnumerable<T> Choice { get; set; }
    ICardChoiceMode<T> Mode { get; set; }

    IEnumerable<T> ChooseAutomatically();
}
