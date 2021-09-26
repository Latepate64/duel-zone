using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class AttackerChoice : Choice
    {
        public IEnumerable<IGrouping<Guid, IEnumerable<Guid>>> Options { get; set; }

        public AttackerChoice(Guid player, IEnumerable<IGrouping<Guid, IEnumerable<Guid>>> options) : base(player)
        {
            Options = options;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Options = null;
            }
        }
    }

    public class AttackerDecision : Decision
    {
        public Tuple<Guid, Guid> Decision { get; private set; }

        public AttackerDecision(Tuple<Guid, Guid> decision)
        {
            Decision = decision;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Decision = null;
            }
        }
    }
}
