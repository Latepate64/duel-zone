using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Choices;

namespace Engine.Choices;

public sealed class AnyNumberOfCardsChoiceMode<T> : ICardChoiceMode<T> where T : ICard
{
    public bool CanBeChosenAutomatically(IEnumerable<T> cards)
    {
        return !cards.Any();
    }

    public IEnumerable<T> ChooseAutomatically(IEnumerable<T> choosableCards)
    {
        return choosableCards;
    }

    public bool IsValid(IEnumerable<T> chosenCards)
    {
        return true;
    }
}
