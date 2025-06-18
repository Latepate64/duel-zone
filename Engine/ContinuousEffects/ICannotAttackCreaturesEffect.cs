namespace Engine.ContinuousEffects
{
    public interface ICannotAttackCreaturesEffect : IContinuousEffect
    {
        bool CannotAttackCreature(Creature attacker, Creature target, IGame game);
    }
}
