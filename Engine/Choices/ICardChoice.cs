using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface ICardChoice : IChoice
    {
        bool CanBeChosenAutomatically { get; }
        IEnumerable<Card> Cards { get; set; }
        IEnumerable<Card> Choice { get; set; }
        ICardChoiceMode Mode { get; set; }

        IEnumerable<Card> ChooseAutomatically();
    }

    public class CardChoice : Choice, ICardChoice
    {
        public CardChoice(ICardChoice choice) : base(choice)
        {
            Cards = choice.Cards;
            Choice = choice.Choice;
            Mode = choice.Mode;
        }

        public CardChoice(IPlayer maker, string description, ICardChoiceMode mode, params Card[] cards) : base(maker, description)
        {
            Cards = cards;
            Mode = mode;
        }

        public IEnumerable<Card> Cards { get; set; }
        public IEnumerable<Card> Choice { get; set; }
        public ICardChoiceMode Mode { get; set; }
        public bool CanBeChosenAutomatically => Mode.CanBeChosenAutomatically(Cards);

        public IEnumerable<Card> ChooseAutomatically()
        {
            return Mode.ChooseAutomatically(Cards);
        }

        public override bool IsValid()
        {
            return Mode.IsValid(Choice) && Choice.All(chosen => Cards.Contains(chosen));
        }
    }
}
