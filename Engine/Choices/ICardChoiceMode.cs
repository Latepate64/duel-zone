using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface ICardChoiceMode
    {
        bool CanBeChosenAutomatically(IEnumerable<Card> cards);
        IEnumerable<Card> ChooseAutomatically(IEnumerable<Card> choosableCards);
        bool IsValid(IEnumerable<Card> chosenCards);
    }

    public interface IBoundedCardChoiceMode : ICardChoiceMode
    {
        int Min { get; }
        int Max { get; }
    }

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

        public bool IsValid(IEnumerable<Card> chosenCards)
        {
            return chosenCards.Count() >= Min && chosenCards.Count() <= Max;
        }

        public bool CanBeChosenAutomatically(IEnumerable<Card> choosableCards)
        {
            return choosableCards.Count() <= Min;
        }

        public IEnumerable<Card> ChooseAutomatically(IEnumerable<Card> cards)
        {
            return cards;
        }
    }

    public class AnyNumberOfCardsChoiceMode : ICardChoiceMode
    {
        public bool CanBeChosenAutomatically(IEnumerable<Card> cards)
        {
            return !cards.Any();
        }

        public IEnumerable<Card> ChooseAutomatically(IEnumerable<Card> choosableCards)
        {
            return choosableCards;
        }

        public bool IsValid(IEnumerable<Card> chosenCards)
        {
            return true;
        }
    }
}
