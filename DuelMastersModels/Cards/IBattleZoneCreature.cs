namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Interface for creatures that exist in battle zone.
    /// </summary>
    public interface IBattleZoneCreature : IBattleZoneCard, ICreature, ITappable, ISummoningSickness
    {
    }
}
