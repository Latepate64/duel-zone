namespace Engine.ContinuousEffects
{
    public interface IAttacksIfAbleEffect : IContinuousEffect
    {
        bool AttacksIfAble(ICard creature);
    }
}
