using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public class SilentSkillSelection : GuidSelection
    {
        public SilentSkillSelection()
        {
        }

        public SilentSkillSelection(Guid player, IEnumerable<ICard> options) : base(player, options.Select(x => x.Id))
        {
        }

        public override string ToString()
        {
            return "Choose which creatures you want to keep tapped to use their Silent skill abilities. Unchosen creatures will untap instead.";
        }
    }
}
