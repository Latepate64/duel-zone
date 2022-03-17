using System;

namespace Engine
{
    public enum CompareMode { Min, Exact, Max }

    public abstract class NumberFilter
    {
        public CompareMode Mode { get; }

        public int Number { get; }

        protected NumberFilter(CompareMode mode, int number)
        {
            Mode = mode;
            Number = number;
        }

        public abstract bool Applies(Card card);
        public abstract override string ToString();
    }

    sealed public class PowerFilter : NumberFilter
    {
        public PowerFilter(CompareMode mode, int power) : base(mode, power)
        {
        }

        public override bool Applies(Card card)
        {
            return Mode switch
            {
                CompareMode.Min => card.Power >= Number,
                CompareMode.Exact => card.Power == Number,
                CompareMode.Max => card.Power <= Number,
                _ => throw new NotImplementedException(),
            };
        }

        public override string ToString()
        {
            var ending = Mode switch
            {
                CompareMode.Min => "or more",
                CompareMode.Exact => "",
                CompareMode.Max => "or less",
                _ => throw new NotImplementedException(),
            };
            return $"that have power {Number}{ending}";
        }
    }

    public interface IPowerFilterable
    {
        public PowerFilter PowerFilter { get; }
    }

    public class ManaCostFilter : NumberFilter
    {
        public ManaCostFilter(CompareMode mode, int manaCost) : base(mode, manaCost)
        {
        }

        public override bool Applies(Card card)
        {
            return Mode switch
            {
                CompareMode.Min => card.ManaCost >= Number,
                CompareMode.Exact => card.ManaCost == Number,
                CompareMode.Max => card.ManaCost <= Number,
                _ => throw new NotImplementedException(),
            };
        }

        public override string ToString()
        {
            var ending = Mode switch
            {
                CompareMode.Min => "or more",
                CompareMode.Exact => "",
                CompareMode.Max => "or less",
                _ => throw new NotImplementedException(),
            };
            return $"that cost {Number}{ending}";
        }
    }

    public interface IManaCostFilterable
    {
        public ManaCostFilter ManaCostFilter { get; }
    }
}
