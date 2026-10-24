namespace Interfaces.ContinuousEffects
{
    public interface IPlayerCannotUntapCardsInManaZoneAtStartOfTurn : IContinuousEffect
    {
        bool PlayerCannotUntapCardsInManaZoneAtStartOfTurn(IPlayerV2 player);
    }
}
