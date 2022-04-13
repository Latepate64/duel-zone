using System;

namespace Engine.ContinuousEffects
{
    public interface IContinuousEffect : ITimestampable, IDisposable
    {
        Guid SourceAbility { get; set; }

        IContinuousEffect Copy();
    }
}