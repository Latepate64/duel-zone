using System;

namespace Engine
{
    public abstract class Condition : ICopyable<Condition>
    {
        public CardFilter Filter { get; }

        protected Condition(CardFilter filter)
        {
            Filter = filter;
        }

        protected Condition(Condition condition)
        {
            Filter = condition.Filter.Copy();
        }

        public abstract bool Applies(Game game, Guid player);

        public override abstract string ToString();

        public abstract Condition Copy();
    }
}
