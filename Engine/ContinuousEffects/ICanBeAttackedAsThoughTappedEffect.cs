namespace Engine.ContinuousEffects
{
    public interface ICanBeAttackedAsThoughTappedEffect : IContinuousEffect
    {
        bool Applies(Card targetOfAttack);
    }
}
