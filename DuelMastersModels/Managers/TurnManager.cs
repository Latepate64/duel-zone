using DuelMastersModels.PlayerActions;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Managers
{
    internal class TurnManager
    {
        internal ITurn CurrentTurn => _turns.Last();

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        private readonly Collection<ITurn> _turns = new Collection<ITurn>();

        internal IPlayerAction StartNewTurn(IPlayer activePlayer, Duel duel)
        {
            ITurn turn = new Turn(activePlayer, _turns.Count + 1);
            _turns.Add(turn);
            return turn.Start(duel);
        }
    }
}
