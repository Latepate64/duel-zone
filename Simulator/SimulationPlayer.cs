using DuelMastersModels;
using DuelMastersModels.Choices;
using System;
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

        public override CardUsageDecision Choose(CardUsageChoice cardUsageChoice)
        {
            var choice = cardUsageChoice.Options.First();
            var second = choice.First().First();
            return new CardUsageDecision(new UseCardContainer { ToUse = choice.Key, Manas = second });
        }

        public override AttackerDecision Choose(AttackerChoice attackerChoice)
        {
            var choice = attackerChoice.Options.First();
            var second = choice.First().Last();
            return new AttackerDecision(new Tuple<Guid, Guid>(choice.Key, second));
        }
    }
}
