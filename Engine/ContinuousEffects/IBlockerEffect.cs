namespace Engine.ContinuousEffects
{
    public interface IBlockerEffect : IContinuousEffect
    {
        bool CanBlock(Creature blocker, Creature attacker, IGame game);
    }
}
