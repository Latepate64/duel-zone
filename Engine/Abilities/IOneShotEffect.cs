namespace Engine.Abilities
{
    public interface IOneShotEffect : IEffect
    {
        void Apply(IGame game, IAbility source);
        IOneShotEffect Copy();
        void Dispose();
        string ToString();
    }
}