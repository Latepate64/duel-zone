using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public class EnumChoice : Choice
    {
        public List<Enum> Excluded { get; set; }

        public EnumChoice(Guid player, List<Enum> excluded) : base(player)
        {
            Excluded = excluded;
        }

        protected override void Dispose(bool disposing)
        {
            Excluded = null;
        }

        public override string ToString()
        {
            return $"Choose other than {string.Join(", ", Excluded)}.";
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
