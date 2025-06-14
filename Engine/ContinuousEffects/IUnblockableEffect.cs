namespace Engine.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool CannotBeBlocked(Card attacker, Card blocker, IAttackable targetOfAttack, IGame game);
    }
}
