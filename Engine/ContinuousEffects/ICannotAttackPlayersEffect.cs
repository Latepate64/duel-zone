namespace Engine.ContinuousEffects
{
    public interface ICannotAttackPlayersEffect : IContinuousEffect
    {
        bool CannotAttackPlayers(ICard attacker, IGame game);
    }
}
