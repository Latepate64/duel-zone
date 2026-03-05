namespace Interfaces;

public interface IOneShotEffect : IEffect
{
    void Apply(IGame game);
    IOneShotEffect Copy();
    string ToString();
}
