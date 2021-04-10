using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System.Collections.Generic;

namespace DuelMastersModels.Managers
{
    public interface IPlayerActionManager
    {
        IPlayerAction Progress<T>(IEnumerable<T> cards) where T : class, ICard;
        void SetCurrentPlayerAction(IPlayerAction playerAction);
    }
}