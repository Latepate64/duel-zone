namespace Engine.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool CannotBeBlocked(Creature attacker, Creature blocker, IAttackable targetOfAttack, IGame game);
    }
}
