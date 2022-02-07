﻿using Engine;
using Common.Choices;
using System;
using System.Linq;
using System.Collections.Generic;

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
            if (guidSelection is ChargeManaSelection cms)
            {
                if (Hand.Cards.Count > 1)
                {
                    return new GuidDecision { Decision = new List<Guid> { cms.Options.First() } };
                }
                else
                {
                    return new GuidDecision();
                }
            }
            else if (guidSelection is UseCardSelection use)
            {
                return new GuidDecision { Decision = new List<Guid> { use.Options.First() } };
            }
            else
            {
                var amount = rnd.Next(guidSelection.MinimumSelection, guidSelection.MaximumSelection + 1);
                var selected = guidSelection.Options.OrderBy(x => rnd.Next()).Take(amount);
                return new GuidDecision(selected);
            }
        }
    }
}
