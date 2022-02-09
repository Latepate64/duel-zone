using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class CardSelectionInEffect : CardSelection
    {
        private readonly string _text;

        public CardSelectionInEffect()
        {
        }

        public CardSelectionInEffect(Guid player, IEnumerable<Card> options, int minimumSelection, int maximumSelection, string text) : base(player, options, minimumSelection, maximumSelection)
        {
            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
