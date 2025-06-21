namespace Engine.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool CannotBeBlocked(ICreature attacker, ICreature blocker, IAttackable targetOfAttack, IGame game);
    }
}
