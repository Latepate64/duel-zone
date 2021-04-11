using DuelMastersModels.Choices;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Managers
{
    public class TurnManager : ITurnManager
    {
        public ITurn CurrentTurn => _turns.Last();

        public IChoice StartTurn(IPlayer activePlayer, IDuel duel)
        {
            ITurn turn = new Turn(activePlayer, _turns.Count + 1);
            _turns.Add(turn);
            return turn.ChangeStep(duel);
        }

        /// <summary>
        /// All the turns of the duel that have been or are processed, in order.
        /// </summary>
        private readonly Collection<ITurn> _turns = new Collection<ITurn>();
    }
}
