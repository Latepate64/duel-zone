using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice, ICardUsageChoice, IAttackerChoice, IEndTurnChoice
    {
        public IEnumerable<IHandCard> UseCards { get; }
        public IEnumerable<IBattleZoneCreature> AttackCreatures { get; }
        public bool TurnEndable { get; }

        public CardUsageChoice(IPlayer player) : base(player)
        {
        }
    }
}
