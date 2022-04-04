namespace Engine.ContinuousEffects
{
    public interface ICannotAttackEffect : IContinuousEffect
    {
        bool Applies(IGame game);
    }
}
