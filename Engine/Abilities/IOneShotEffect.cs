namespace Engine.Abilities
{
    public interface IOneShotEffect
    {
        object Apply(IGame game, IAbility source);
        IOneShotEffect Copy();
        void Dispose();
        string ToString();
    }
}