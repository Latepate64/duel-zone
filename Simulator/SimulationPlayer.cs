using Engine;
using Common.Choices;
using System;
using System.Linq;

namespace Simulator
{
    class SimulationPlayer : Player
    {
        public SimulationPlayer() : base() { }

        public SimulationPlayer(SimulationPlayer player) : base(player) { }

        static readonly Random Rnd = new();

        public override GuidDecision ClientChoose(GuidSelection guidSelection)
        {
            var amount = Rnd.Next(guidSelection.MinimumSelection, guidSelection.MaximumSelection + 1);
            var selected = guidSelection.Options.OrderBy(x => Rnd.Next()).Take(amount);
            return new GuidDecision(selected);
        }

        public override YesNoDecision ClientChoose(YesNoChoice yesNoChoice)
        {
            return new YesNoDecision(true);
        }
    }
}
