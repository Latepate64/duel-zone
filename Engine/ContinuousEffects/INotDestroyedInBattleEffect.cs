namespace Engine.ContinuousEffects
{
    public interface INotDestroyedInBattleEffect : IContinuousEffect
    {
        bool Applies(ICard against, ICreature creature, IGame game);
    }
}
