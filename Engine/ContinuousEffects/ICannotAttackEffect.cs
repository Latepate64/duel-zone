namespace Engine.ContinuousEffects
{
    public interface ICannotAttackEffect : IContinuousEffect
    {
        bool CannotAttack(Card attacker, IGame game);
    }
}
