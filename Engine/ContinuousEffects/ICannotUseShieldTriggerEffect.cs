namespace Engine.ContinuousEffects
{
    public interface ICannotUseShieldTriggerEffect : IContinuousEffect //TODO: Apply in engine
    {
        bool Applies(Card shield, IGame game);
    }
}
