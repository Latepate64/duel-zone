namespace Engine.ContinuousEffects
{
    public interface ICannotBeAttackedEffect : IContinuousEffect
    {
        bool Applies(ICard attacker);
    }
}
