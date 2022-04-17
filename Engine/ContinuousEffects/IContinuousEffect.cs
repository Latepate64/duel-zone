using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : ITimestampable
    {
        Guid SourceAbility { get; set; }

        IContinuousEffect Copy();
    }
}