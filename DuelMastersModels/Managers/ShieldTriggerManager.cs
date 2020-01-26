using DuelMastersModels.Cards;

namespace DuelMastersModels.Managers
{
    internal class ShieldTriggerManager
    {
        internal ReadOnlyCardCollection<IHandCard> ShieldTriggersToUse => new ReadOnlyCardCollection<IHandCard>(_shieldTriggersToUse);

        internal void AddShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggersToUse.Add(card);
        }

        internal void RemoveShieldTriggerToUse(IHandCard card)
        {
            _shieldTriggersToUse.Remove(card);
        }

        private readonly CardCollection<IHandCard> _shieldTriggersToUse = new CardCollection<IHandCard>();
    }
}
