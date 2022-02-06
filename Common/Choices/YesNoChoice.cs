using System;

namespace Common.Choices
{
    public class YesNoChoice : Choice
    {
        string _text;
        
        public YesNoChoice() { }

        public YesNoChoice(Guid player, string text) : base(player)
        {
            _text = text;
        }

        protected override void Dispose(bool disposing)
        {
        }

        public override string ToString()
        {
            return _text;
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