using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Managers
{
    internal class ShieldTriggerManager
    {
        internal IEnumerable<IHandCard> ShieldTriggersToUse => new ReadOnlyCollection<IHandCard>(_shieldTriggersToUse);

        internal void AddShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggersToUse.Add(card);
        }

        internal void RemoveShieldTriggerToUse(IHandCard card)
        {
            _ = _shieldTriggersToUse.Remove(card);
        }

        private readonly Collection<IHandCard> _shieldTriggersToUse = new Collection<IHandCard>();
    }
}
