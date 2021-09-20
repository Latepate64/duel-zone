using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class AttackerChoice : Choice
    {
        public IEnumerable<Creature> AttackCreatures { get; }
        public bool TurnEndable { get; }

        public AttackerChoice(Player player) : base(player)
        {
        }
    }
}
