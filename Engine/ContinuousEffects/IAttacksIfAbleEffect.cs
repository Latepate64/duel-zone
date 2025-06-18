namespace Engine.ContinuousEffects
{
    public interface IAttacksIfAbleEffect : IContinuousEffect
    {
        bool AttacksIfAble(Creature creature, IGame game);
    }
}
