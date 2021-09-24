using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class AttackerChoice : Choice
    {
        public IEnumerable<IGrouping<Guid, IEnumerable<Guid>>> Options { get; }

        public Tuple<Guid, Guid> Selected { get; set; }

        public AttackerChoice(Guid player, IEnumerable<IGrouping<Guid, IEnumerable<Guid>>> options) : base(player)
        {
            Options = options;
        }

        public AttackerChoice(AttackerChoice choice, Tuple<Guid, Guid> selected) : base(choice.Player)
        {
            Options = new List<IGrouping<Guid, IEnumerable<Guid>>>(choice.Options);
            Selected = selected;
        }

        public AttackerChoice(Tuple<Guid, Guid> selected, Guid player) : base(player)
        {
            Selected = selected;
        }
    }
}
