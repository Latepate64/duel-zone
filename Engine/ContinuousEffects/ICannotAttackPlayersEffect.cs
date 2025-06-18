namespace Engine.ContinuousEffects
{
    public interface ICannotAttackPlayersEffect : IContinuousEffect
    {
        bool CannotAttackPlayers(Creature attacker, IGame game);
    }
}
