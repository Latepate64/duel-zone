namespace Engine.ContinuousEffects
{
    public interface ICanAttackUntappedCreaturesEffect : IContinuousEffect
    {
        bool Applies(ICard targetOfAttack, IGame game);
    }
}
