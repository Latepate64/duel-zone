namespace Engine.ContinuousEffects
{
    public interface ICannotAttackCreaturesEffect : IContinuousEffect
    {
        bool Applies(ICard attacker, ICard target, IGame game);
    }
}
