using System;

namespace Engine
{
    public abstract class Condition : ICopyable<Condition>
    {
        public ICardFilter Filter { get; }

        protected Condition(ICardFilter filter)
        {
            Filter = filter;
        }

        protected Condition(Condition condition)
        {
            Filter = condition.Filter.Copy();
        }

        public abstract bool Applies(IGame game, Guid player);

        public override abstract string ToString();

        public abstract Condition Copy();
    }
}
