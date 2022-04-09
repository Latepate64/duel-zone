namespace Engine.ContinuousEffects
{
    public interface IBreaksAdditionalShieldsEffect : IContinuousEffect
    {
        int GetAmount(IGame game, ICard creature);
    }
}
