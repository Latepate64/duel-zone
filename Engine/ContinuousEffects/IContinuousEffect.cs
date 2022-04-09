using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : ITimestampable, IDisposable
    {
        Guid Controller { get; set; }
        Guid SourceAbility { get; set; }

        IContinuousEffect Copy();
    }
}