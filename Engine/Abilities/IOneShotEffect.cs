namespace Engine.Abilities
{
    public interface IOneShotEffect
    {
        void Apply(IGame game, IAbility source);
        IOneShotEffect Copy();
        void Dispose();
        string ToString();
    }
}