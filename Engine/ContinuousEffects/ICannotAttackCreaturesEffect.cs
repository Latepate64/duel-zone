namespace Engine.ContinuousEffects
{
    public interface ICannotAttackCreaturesEffect : IContinuousEffect
    {
        bool CannotAttackCreature(ICard attacker, ICard target);
    }
}
