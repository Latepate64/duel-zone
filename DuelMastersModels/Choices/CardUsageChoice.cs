using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class CardUsageChoice : Choice
    {
        public IEnumerable<Card> UseCards { get; }
        public IEnumerable<Creature> AttackCreatures { get; }
        public bool TurnEndable { get; }

        public CardUsageChoice(IPlayer player) : base(player)
        {
        }
    }
}
