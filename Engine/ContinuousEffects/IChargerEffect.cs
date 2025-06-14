namespace Engine.ContinuousEffects
{
    public interface IChargerEffect : IReplacementEffect
    {
        bool Applies(Card card, IGame game);
    }
}
