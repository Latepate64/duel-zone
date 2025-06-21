namespace Interfaces.ContinuousEffects
{
    public interface ICannotAttackEffect : IContinuousEffect
    {
        bool CannotAttack(ICreature creature, IGame game);
    }
}
