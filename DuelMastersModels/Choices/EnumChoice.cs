using System;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class EnumChoice : Choice
    {
        public IEnumerable<Enum> Excluded { get; private set; }

        public EnumChoice(Guid player, IEnumerable<Enum> excluded) : base(player)
        {
            Excluded = excluded;
        }

        protected override void Dispose(bool disposing)
        {
            Excluded = null;
        }
    }

    public class EnumDecision : Decision
    {
        public Enum Decision { get; private set; }

        public EnumDecision(Enum decision)
        {
            Decision = decision;
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
