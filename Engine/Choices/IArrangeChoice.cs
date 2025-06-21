using System.Collections.Generic;
using System.Linq;

namespace Engine.Choices
{
    public interface IArrangeChoice
    {
        IEnumerable<ICard> Cards { get; }
        ICard[] Rearranged { get; }
    }

    public class ArrangeChoice : Choice, IArrangeChoice
    {
        public ArrangeChoice(ArrangeChoice choice) : base(choice)
        {
            Cards = choice.Cards;
            Rearranged = choice.Rearranged;
        }

        public ArrangeChoice(IPlayer maker, IEnumerable<ICard> cards) : base(maker, "Put back in any order.")
        {
            Cards = cards;
        }

        public IEnumerable<ICard> Cards { get; }
        public ICard[] Rearranged { get; set; }

        public override bool IsValid()
        {
            return Cards.Count() == Rearranged.Count() && Cards.All(x => Rearranged.Contains(x));
        }
    }
}
