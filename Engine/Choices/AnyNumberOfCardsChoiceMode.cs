using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices;

public class AnyNumberOfCardsChoiceMode : ICardChoiceMode
{
    public bool CanBeChosenAutomatically(IEnumerable<ICard> cards)
    {
        return !cards.Any();
    }

    public IEnumerable<ICard> ChooseAutomatically(IEnumerable<ICard> choosableCards)
    {
        return choosableCards;
    }

    public bool IsValid(IEnumerable<ICard> chosenCards)
    {
        return true;
    }
}