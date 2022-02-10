using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class ReplacementEffectSelection : GuidSelection
    {
        public ReplacementEffectSelection()
        {
        }

        public ReplacementEffectSelection(Guid player, IEnumerable<Guid> options, int minimumSelection, int maximumSelection) : base(player, options, minimumSelection, maximumSelection)
        {
        }

        public override string ToString()
        {
            return "Choose a replacement effect to apply.";
        }
    }
}
