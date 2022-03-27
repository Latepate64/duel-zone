using Common.GameEvents;
using System;

namespace Engine
{
    public interface IDuration : IDisposable
    {
        IDuration Copy();
        string ToString();
        bool ShouldExpire(IGameEvent gameEvent);
    }
}