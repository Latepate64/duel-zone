using System.Collections.Generic;

namespace Engine.Choices;

public interface ICardChoiceMode
{
    bool CanBeChosenAutomatically(IEnumerable<ICard> cards);
    IEnumerable<ICard> ChooseAutomatically(IEnumerable<ICard> choosableCards);
    bool IsValid(IEnumerable<ICard> chosenCards);
}