namespace Engine.ContinuousEffects
{
    public interface ICannotAttackCreaturesEffect : IContinuousEffect
    {
        bool CannotAttackCreature(Card attacker, Card target, IGame game);
    }
}
