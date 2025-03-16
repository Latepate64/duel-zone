using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices;

public class BoundedCardChoiceMode : IBoundedCardChoiceMode
{
    public BoundedCardChoiceMode(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public BoundedCardChoiceMode(IBoundedCardChoiceMode mode)
    {
        Min = mode.Min;
        Max = mode.Max;
    }

    public int Min { get; }
    public int Max { get; }

    public bool IsValid(IEnumerable<ICard> chosenCards)
    {
        return chosenCards.Count() >= Min && chosenCards.Count() <= Max;
    }

    public bool CanBeChosenAutomatically(IEnumerable<ICard> choosableCards)
    {
        return choosableCards.Count() <= Min;
    }

    public IEnumerable<ICard> ChooseAutomatically(IEnumerable<ICard> cards)
    {
        return cards;
    }
}
