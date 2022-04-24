namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotUntapCardsInManaZoneAtStartOfTurn : IContinuousEffect
    {
        bool PlayerCannotUntapCardsInManaZoneAtStartOfTurn(IPlayer player);
    }
}
