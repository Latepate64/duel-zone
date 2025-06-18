namespace Engine.ContinuousEffects
{
    public interface INotDestroyedInBattleEffect : IContinuousEffect
    {
        bool Applies(Card against, Creature creature, IGame game);
    }
}
