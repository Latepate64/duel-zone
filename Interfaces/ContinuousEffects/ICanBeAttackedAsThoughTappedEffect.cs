namespace Interfaces.ContinuousEffects
{
    public interface ICanBeAttackedAsThoughTappedEffect : IContinuousEffect
    {
        bool Applies(ICard targetOfAttack);
    }
}
