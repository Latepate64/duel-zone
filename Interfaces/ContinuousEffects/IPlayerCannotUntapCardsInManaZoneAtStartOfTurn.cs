namespace Interfaces.ContinuousEffects
{
    public interface IPlayerCannotUntapCardsInManaZoneAtStartOfTurn : IContinuousEffect
    {
        bool PlayerCannotUntapCardsInManaZoneAtStartOfTurn(IPlayer player);
    }
}
