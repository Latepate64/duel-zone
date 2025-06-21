namespace Engine.ContinuousEffects
{
    public interface IAttacksIfAbleEffect : IContinuousEffect
    {
        bool AttacksIfAble(ICreature creature, IGame game);
    }
}
