namespace Engine.ContinuousEffects
{
    public interface IAttacksIfAbleEffect : IContinuousEffect
    {
        bool Applies(ICard creature, IGame game);
    }
}
