using System;

namespace Engine
{
    sealed public class TargetFilter : CardFilter, ITargetFilterable
    {
        /// <summary>
        /// Target and/or source of the filter. Not all filters need to consider this in applying the filter. (eg. for creature with Speed Attacker ability this is the creature, for Super Sonic Jetpack selection this is the target of the effect)
        /// </summary>
        public Guid Target { get; set; }

        public TargetFilter()
        {
        }

        public TargetFilter(TargetFilter filter)
        {
            Target = filter.Target;
        }

        public override CardFilter Copy()
        {
            return new TargetFilter(this);
        }

        public override bool Applies(Card card, Game game, IPlayer player)
        {
            return player != null && Target == card?.Id;
        }

        public override string ToString()
        {
            return Target.ToString();
        }
    }

    public interface ITargetFilterable
    {
        public Guid Target { get; set; }
    }
}
