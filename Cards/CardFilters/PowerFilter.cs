using Engine;
using System;

namespace Cards.CardFilters
{
    enum PowerMode { Min, Exact, Max }

    class PowerFilter
    {
        public PowerMode Mode { get; }

        public int Power { get; }

        public PowerFilter(PowerMode mode, int power)
        {
            Mode = mode;
            Power = power;
        }

        public bool Applies(Card card)
        {
            return Mode switch
            {
                PowerMode.Min => card.Power >= Power,
                PowerMode.Exact => card.Power == Power,
                PowerMode.Max => card.Power <= Power,
                _ => throw new NotImplementedException(),
            };
        }

        public override string ToString()
        {
            var ending = Mode switch
            {
                PowerMode.Min => "or more",
                PowerMode.Exact => "",
                PowerMode.Max => "or less",
                _ => throw new NotImplementedException(),
            };
            return $"that have power {Power}{ending}";
        }
    }
}