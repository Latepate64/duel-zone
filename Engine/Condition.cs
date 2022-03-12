using System;

namespace Engine
{
    public abstract class Condition
    {
        public abstract bool Applies(Game game, Guid player);

        public override abstract string ToString();
    }
}
