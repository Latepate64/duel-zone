namespace Engine.ContinuousEffects
{
    public interface ICannotUseShieldTriggerEffect : IContinuousEffect //TODO: Apply in engine
    {
        bool Applies(ICard card, IGame game);
    }
}
