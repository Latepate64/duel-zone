using DuelMastersModels;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace Simulator
{
    class SimulationPlayer : Player
    {
        public SimulationPlayer() : base() { }

        public SimulationPlayer(SimulationPlayer player) : base(player) { }

        public override GuidDecision Choose(GuidSelection guidSelection)
        {
            return new GuidDecision(new List<System.Guid> { guidSelection.Options.First() });
        }

        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            return new YesNoDecision(true);
        }

        public override Player Copy()
        {
            return new SimulationPlayer(this);
        }
    }
}
