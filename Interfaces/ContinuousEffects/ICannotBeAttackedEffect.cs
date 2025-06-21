namespace Interfaces.ContinuousEffects
{
    public interface ICannotBeAttackedEffect : IContinuousEffect
    {
        bool Applies(ICreature attacker, ICreature targetOfAttack, IGame game);
    }
}
