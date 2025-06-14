namespace Engine.ContinuousEffects
{
    public interface IAttacksIfAbleEffect : IContinuousEffect
    {
        bool AttacksIfAble(Card creature, IGame game);
    }
}
