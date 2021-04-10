using DuelMastersModels.PlayerActions;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Managers
{
    internal class TurnManager
    {
        internal Turn CurrentTurn => _turns.Last();

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        private readonly Collection<Turn> _turns = new Collection<Turn>();

        internal PlayerAction StartNewTurn(IPlayer activePlayer, IPlayer nonActivePlayer, Duel duel)
        {
            Turn turn = new Turn(activePlayer, nonActivePlayer, _turns.Count + 1);
            _turns.Add(turn);
            return turn.Start(duel);
        }
    }
}
