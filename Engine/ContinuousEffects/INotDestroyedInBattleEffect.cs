namespace Engine.ContinuousEffects
{
    public interface INotDestroyedInBattleEffect : IContinuousEffect
    {
        bool Applies(ICard against, ICard creature);
    }
}
