using System.Collections.Generic;

namespace Engine.Choices
{
    public interface ICardChoice : IChoice
    {
        bool CanBeChosenAutomatically { get; }
        IEnumerable<ICard> Cards { get; set; }
        IEnumerable<ICard> Choice { get; set; }
        ICardChoiceMode Mode { get; set; }

        IEnumerable<ICard> ChooseAutomatically();
    }

    public class CardChoice : Choice, ICardChoice
    {
        public CardChoice(ICardChoice choice) : base(choice)
        {
            Cards = choice.Cards;
            Choice = choice.Choice;
            Mode = choice.Mode;
        }

        public CardChoice(IPlayer maker, string description, ICardChoiceMode mode, params ICard[] cards) : base(maker, description)
        {
            Cards = cards;
            Mode = mode;
        }

        public IEnumerable<ICard> Cards { get; set; }
        public IEnumerable<ICard> Choice { get; set; }
        public ICardChoiceMode Mode { get; set; }
        public bool CanBeChosenAutomatically => Mode.CanBeChosenAutomatically(Cards);

        public IEnumerable<ICard> ChooseAutomatically()
        {
            return Mode.ChooseAutomatically(Cards);
        }

        public override bool IsValid()
        {
            return Mode.IsValid(Choice);
        }
    }
}
