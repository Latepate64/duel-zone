namespace Engine.ContinuousEffects
{
    public interface IIgnoreCannotAttackPlayersEffects : IContinuousEffect
    {
        bool IgnoreCannotAttackPlayersEffects(Card attacker, IGame game);
    }
}
