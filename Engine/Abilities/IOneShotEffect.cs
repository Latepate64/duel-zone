namespace Engine.Abilities
{
    public interface IOneShotEffect : IEffect
    {
        void Apply();
        IOneShotEffect Copy();
        void Dispose();
        string ToString();
    }
}