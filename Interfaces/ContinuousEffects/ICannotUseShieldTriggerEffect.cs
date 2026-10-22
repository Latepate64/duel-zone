namespace Interfaces.ContinuousEffects
{
    public interface ICannotUseShieldTriggerEffect : IContinuousEffect
    {
        bool CannotUseShieldTrigger(ICard shield, IGame game);
    }
}
