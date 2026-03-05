using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Choices;

namespace Engine.Choices;

public sealed class BoundedCardChoiceMode<T> : IBoundedCardChoiceMode<T> where T : ICard
{
    public BoundedCardChoiceMode(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public BoundedCardChoiceMode(IBoundedCardChoiceMode<T> mode)
    {
        Min = mode.Min;
        Max = mode.Max;
    }

    public int Min { get; }
    public int Max { get; }

    public bool IsValid(IEnumerable<T> chosenCards)
    {
        return chosenCards.Count() >= Min && chosenCards.Count() <= Max;
    }

    public bool CanBeChosenAutomatically(IEnumerable<T> choosableCards)
    {
        return choosableCards.Count() <= Min;
    }

    public IEnumerable<T> ChooseAutomatically(IEnumerable<T> cards)
    {
        return cards;
    }
}
