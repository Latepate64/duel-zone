﻿using DuelMastersModels;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace Simulator
{
    class SimulationPlayer : Player
    {
        public SimulationPlayer() : base() { }

        public SimulationPlayer(SimulationPlayer player) : base(player) { }

        static readonly Random rnd = new();

        public override GuidDecision Choose(GuidSelection guidSelection)
        {
            var amount = rnd.Next(guidSelection.MinimumSelection, guidSelection.MaximumSelection + 1);
            var selected = guidSelection.Options.OrderBy(x => rnd.Next()).Take(amount);
            return new GuidDecision(selected);
        }

        public override YesNoDecision Choose(YesNoChoice yesNoChoice)
        {
            return new YesNoDecision(true);
        }

        public override Player Copy()
        {
            return new SimulationPlayer(this);
        }

        public override AttackerDecision Choose(AttackerChoice attackerChoice)
        {
            var choice = attackerChoice.Options.First();
            var second = choice.First().Last();
            return new AttackerDecision(new Tuple<Guid, Guid>(choice.Key, second));
        }
    }
}
