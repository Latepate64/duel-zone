using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class ReplacementEffectSelection : BoundedGuidSelection
    {
        public ReplacementEffectSelection()
        {
        }

        public ReplacementEffectSelection(Guid player, IEnumerable<Guid> options) : base(player, options, 1, 1)
        {
        }

        public override string ToString()
        {
            return "Choose a replacement effect to apply.";
        }
    }
}
