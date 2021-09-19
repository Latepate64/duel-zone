using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class AttackerChoice : Choice, IAttackerChoice, IEndTurnChoice
    {
        public IEnumerable<Creature> AttackCreatures { get; }
        public bool TurnEndable { get; }

        public AttackerChoice(IPlayer player) : base(player)
        {
        }
    }
}
