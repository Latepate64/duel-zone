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
            var amount = 0;
            if (guidSelection is BoundedGuidSelection bounded)
            {
                amount = Rnd.Next(bounded.MinimumSelection, bounded.MaximumSelection + 1);
            }
            else
            {
                amount = Rnd.Next(0, guidSelection.Options.Count + 1);
            }
            var selected = guidSelection.Options.OrderBy(x => Rnd.Next()).Take(amount);
            return new GuidDecision(selected);
        }

        public override YesNoDecision ClientChoose(YesNoChoice yesNoChoice)
        {
            return new YesNoDecision(true);
        }
    }
}
