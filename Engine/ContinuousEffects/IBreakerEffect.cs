namespace Engine.ContinuousEffects
{
    public interface IBreakerEffect : IContinuousEffect
    {
        int GetAmount(IGame game);
    }
}
