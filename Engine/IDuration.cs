using Common.GameEvents;
using System;

namespace Engine
{
    public interface IDuration : IDisposable
    {
        string ToString();
        bool ShouldExpire(IGameEvent gameEvent);
    }
}