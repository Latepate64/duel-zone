namespace Engine.ContinuousEffects
{
    public interface IIgnoreCannotAttackPlayersEffects : IContinuousEffect
    {
        bool IgnoreCannotAttackPlayersEffects(ICard attacker, IGame game);
    }
}
