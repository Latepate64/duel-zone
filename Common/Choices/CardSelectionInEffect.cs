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

        public CardSelectionInEffect(Guid player, IEnumerable<Card> options, string text) : base(player, options)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
