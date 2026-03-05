namespace Interfaces.ContinuousEffects
{
    public interface ICannotUseShieldTriggerEffect : IContinuousEffect //TODO: Apply in engine
    {
        bool Applies(ICard shield, IGame game);
    }
}
