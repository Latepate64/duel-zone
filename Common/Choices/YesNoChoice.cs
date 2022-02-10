using System;

namespace Common.Choices
{
    public class YesNoChoice : Choice
    {
        public string Text { get; set; }
        
        public YesNoChoice() { }

        public YesNoChoice(Guid player, string text) : base(player)
        {
            Text = text;
        }

        protected override void Dispose(bool disposing)
        {
        }

        public override string ToString()
        {
            return Text;
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