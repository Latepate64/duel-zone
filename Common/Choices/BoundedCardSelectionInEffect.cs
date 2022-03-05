using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class BoundedCardSelectionInEffect : BoundedCardSelection
    {
        public string Text { get; set; }

        public BoundedCardSelectionInEffect()
        {
        }

        public BoundedCardSelectionInEffect(Guid player, IEnumerable<Card> options, int minimumSelection, int maximumSelection, string text) : base(player, options, minimumSelection, maximumSelection)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
