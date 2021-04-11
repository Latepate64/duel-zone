using DuelMastersModels.Choices;

namespace DuelMastersModels.Managers
{
    public interface ITurnManager
    {
        /// <summary>
        /// The turn that is currently being processed.
        /// </summary>
        ITurn CurrentTurn { get; }

        IChoice StartTurn(IPlayer activePlayer, IDuel duel);
    }
}