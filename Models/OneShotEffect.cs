using Interfaces;

namespace Models;

public partial class OneShotEffect : IGameEvent
{
    public abstract IGameEvent Copy();

    public override bool Equals(object? obj)
    {
        return obj is OneShotEffect;
    }
}
