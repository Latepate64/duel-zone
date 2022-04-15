using Engine;
using Common.Choices;
using System;
using System.Linq;
using Engine.Choices;

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

        public override IPlayer Copy()
        {
            return new SimulationPlayer(this);
        }

        public override T ChooseAbstractly<T>(T choice)
        {
            if (choice is BooleanChoice boolean)
            {
                boolean.Choice = true;
                return boolean as T;
            }
            else if (choice is SubtypeChoice subtype)
            {
                subtype.Choice = Enum.GetValues(typeof(Common.Subtype)).Cast<Common.Subtype>().Except(subtype.Excluded).OrderBy(x => Rnd.Next()).First();
                return subtype as T;
            }
            else if (choice is NumberChoice number)
            {
                number.Choice = Rnd.Next(0, 6);
                return number as T;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
