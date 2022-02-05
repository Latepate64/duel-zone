using System;

namespace Common.Choices
{
    public class YesNoChoice : Choice
    {
        public YesNoChoice() { }

        public YesNoChoice(Guid player) : base(player)
        {
        }

        protected override void Dispose(bool disposing)
        {
        }
    }

    public class YesNoDecision : Decision
    {
        public bool Decision { get; set; }

        public YesNoDecision() { }

        public YesNoDecision(bool decision)
        {
            Decision = decision;
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}