using Engine;
using Common.Choices;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Server
{
    public class ComputerPlayer : Player
    {
        static readonly Random Rnd = new();

        public ComputerPlayer() : base()
        {
        }

        public ComputerPlayer(Player player) : base(player)
        {
        }

        public override int ChooseNumber(string text, int minimum, int? maximum)
        {
            return Rnd.Next(minimum, 6);
        }

        public override Common.Subtype ChooseRace(params Common.Subtype[] excluded)
        {
            return Enum.GetValues(typeof(Common.Subtype)).Cast<Common.Subtype>().Except(excluded).OrderBy(x => Rnd.Next()).First();
        }

        public override YesNoDecision ClientChoose(YesNoChoice yesNoChoice)
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
        }
    }
}
