namespace Engine.ContinuousEffects
{
    public interface IChargerEffect : IContinuousEffect
    {
        bool Applies(ICard card, IGame game);
    }
}
