namespace Engine.Abilities
{
    public interface IOneShotEffect : IEffect
    {
        void Apply(IGame game);
        IOneShotEffect Copy();
        void Dispose();
        string ToString();
    }
}