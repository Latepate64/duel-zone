namespace Engine.ContinuousEffects
{
    public interface ICannotAttackCreaturesEffect : IContinuousEffect
    {
        bool CannotAttackCreature(ICreature attacker, ICreature target, IGame game);
    }
}
