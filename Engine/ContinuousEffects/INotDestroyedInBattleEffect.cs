namespace Engine.ContinuousEffects
{
    public interface INotDestroyedInBattleEffect : IContinuousEffect
    {
        bool Applies(Card against, Card creature, IGame game);
    }
}
