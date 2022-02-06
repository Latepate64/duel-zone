using Engine;
using Common.Choices;
using System;
using System.Linq;

namespace Server
{
    public class ComputerPlayer : Player
    {
        static readonly Random rnd = new();

        public ComputerPlayer() : base()
        {
        }

        public ComputerPlayer(Player player) : base(player)
        {
        }

        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            return new YesNoDecision(true);
        }

        public override GuidDecision ClientChoose(GuidSelection guidSelection)
        {
            var amount = rnd.Next(guidSelection.MinimumSelection, guidSelection.MaximumSelection + 1);
            var selected = guidSelection.Options.OrderBy(x => rnd.Next()).Take(amount);
            return new GuidDecision(selected);
        }
    }
}
