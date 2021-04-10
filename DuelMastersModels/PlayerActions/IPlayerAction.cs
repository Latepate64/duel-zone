namespace DuelMastersModels.PlayerActions
{
    /// <summary>
    /// Interface for actions players may perform.
    /// </summary>
    public interface IPlayerAction
    {
        /// <summary>
        /// Player performing the action.
        /// </summary>
        IPlayer Player { get; }
    }
}
