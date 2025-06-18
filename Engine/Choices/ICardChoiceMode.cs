using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface ICardChoiceMode<T>
    {
        bool CanBeChosenAutomatically(IEnumerable<T> cards);
        IEnumerable<T> ChooseAutomatically(IEnumerable<T> choosableCards);
        bool IsValid(IEnumerable<T> chosenCards);
    }

    public interface IBoundedCardChoiceMode<T> : ICardChoiceMode<T>
    {
        int Min { get; }
        int Max { get; }
    }

    public class BoundedCardChoiceMode<T> : IBoundedCardChoiceMode<T>
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

    public class AnyNumberOfCardsChoiceMode<T> : ICardChoiceMode<T>
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
}
