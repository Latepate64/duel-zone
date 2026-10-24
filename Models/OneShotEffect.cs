using Interfaces;

namespace Models;

public partial class OneShotEffect : IGameEventV3
{
    public abstract OneShotEffect Copy();

    public override bool Equals(object? obj)
    {
        return obj is OneShotEffect;
    }
}
