namespace Engine.ContinuousEffects
{
    public interface ICannotAttackEffect : IContinuousEffect
    {
        bool Applies(ICard creature, IGame game);
    }
}
