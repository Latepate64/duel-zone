namespace Engine.ContinuousEffects
{
    public interface ICannotAttackEffect : IContinuousEffect
    {
        bool CannotAttack(Creature creature, IGame game);
    }
}
