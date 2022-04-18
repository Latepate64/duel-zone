namespace Engine.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game);
    }
}
