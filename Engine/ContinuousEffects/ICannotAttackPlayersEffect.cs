namespace Engine.ContinuousEffects
{
    public interface ICannotAttackPlayersEffect : IContinuousEffect
    {
        bool CannotAttackPlayers(ICreature attacker, IGame game);
    }
}
