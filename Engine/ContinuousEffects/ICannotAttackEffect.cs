namespace Engine.ContinuousEffects
{
    public interface ICannotAttackEffect : IContinuousEffect
    {
        bool CannotAttack(ICard attacker, IGame game);
    }
}
