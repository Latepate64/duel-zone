using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class CardSelectionInEffect : CardSelection
    {
        public string Text { get; set; }

        public CardSelectionInEffect()
        {
        }

        public CardSelectionInEffect(Guid player, IEnumerable<Card> options, int minimumSelection, int maximumSelection, string text) : base(player, options, minimumSelection, maximumSelection)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
