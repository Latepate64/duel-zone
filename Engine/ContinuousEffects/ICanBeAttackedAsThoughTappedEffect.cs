namespace Engine.ContinuousEffects
{
    public interface ICanBeAttackedAsThoughTappedEffect : IContinuousEffect
    {
        bool Applies(ICard targetOfAttack);
    }
}
