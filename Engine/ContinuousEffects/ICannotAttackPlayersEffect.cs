namespace Engine.ContinuousEffects
{
    public interface ICannotAttackPlayersEffect : IContinuousEffect
    {
        bool CannotAttackPlayers(Card attacker, IGame game);
    }
}
