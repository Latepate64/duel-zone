namespace Engine.ContinuousEffects
{
    public interface IBreaksAdditionalShieldsEffect : IContinuousEffect
    {
        int GetAmount(ICard creature);
    }
}
