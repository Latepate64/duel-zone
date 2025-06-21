namespace Interfaces.ContinuousEffects
{
    public interface ICanAttackUntappedCreaturesEffect : IContinuousEffect
    {
        bool CanAttackUntappedCreature(ICreature attacker, ICreature targetOfAttack, IGame game);
    }
}
