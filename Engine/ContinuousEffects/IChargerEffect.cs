namespace Engine.ContinuousEffects
{
    public interface IChargerEffect : IReplacementEffect
    {
        bool Applies(ICard card, IGame game);
    }
}
