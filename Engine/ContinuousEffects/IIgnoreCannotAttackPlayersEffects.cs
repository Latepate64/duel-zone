namespace Engine.ContinuousEffects
{
    public interface IIgnoreCannotAttackPlayersEffects : IContinuousEffect
    {
        bool IgnoreCannotAttackPlayersEffects(ICreature attacker, IGame game);
    }
}
