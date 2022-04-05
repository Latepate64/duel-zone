namespace Engine.ContinuousEffects
{
    public interface IIgnoreCannotAttackPlayersEffects : IContinuousEffect
    {
        bool Applies(ICard attacker, IGame game);
    }
}
