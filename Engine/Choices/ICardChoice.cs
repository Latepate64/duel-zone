using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface ICardChoice<T> : IChoice
    {
        bool CanBeChosenAutomatically { get; }
        IEnumerable<T> Cards { get; set; }
        IEnumerable<T> Choice { get; set; }
        ICardChoiceMode<T> Mode { get; set; }

        IEnumerable<T> ChooseAutomatically();
    }

    public class CardChoice<T> : Choice, ICardChoice<T>
    {
        public CardChoice(ICardChoice<T> choice) : base(choice)
        {
            Cards = choice.Cards;
            Choice = choice.Choice;
            Mode = choice.Mode;
        }

        public CardChoice(Player maker, string description, ICardChoiceMode<T> mode, params T[] cards) : base(maker, description)
        {
            Cards = cards;
            Mode = mode;
        }

        public IEnumerable<T> Cards { get; set; }
        public IEnumerable<T> Choice { get; set; }
        public ICardChoiceMode<T> Mode { get; set; }
        public bool CanBeChosenAutomatically => Mode.CanBeChosenAutomatically(Cards);

        public IEnumerable<T> ChooseAutomatically()
        {
            return Mode.ChooseAutomatically(Cards);
        }

        public override bool IsValid()
        {
            return Mode.IsValid(Choice) && Choice.All(chosen => Cards.Contains(chosen));
        }
    }
}
