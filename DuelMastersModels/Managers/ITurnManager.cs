using DuelMastersModels.PlayerActions;

namespace DuelMastersModels.Managers
{
    public interface ITurnManager
    {
        /// <summary>
        /// The turn that is currently being processed.
        /// </summary>
        ITurn CurrentTurn { get; }

        IPlayerAction StartTurn(IPlayer activePlayer, IDuel duel);
    }
}