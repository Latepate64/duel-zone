namespace Interfaces;

public interface ITriggeredAbility : IResolvableAbility
{
    bool CanTrigger(IGameEvent gameEvent, IGame game);
    bool CheckInterveningIfClause(IGame game);
    ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent);
    /// <summary>
    /// Opponent of the player who controls the ability.
    /// </summary>
    /// <param name="game"></param>
    /// <exception cref="PlayerNotInGameException"></exception>
    /// <returns>Opponent of the player who controls the ability.</returns>
    IPlayer GetOpponent(IGame game);
}
