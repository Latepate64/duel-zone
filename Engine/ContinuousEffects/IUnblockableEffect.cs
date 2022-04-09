namespace Engine.ContinuousEffects
{
    public interface IUnblockableEffect : IContinuousEffect
    {
        bool Applies(ICard attacker, ICard blocker, IGame game);
    }
}
