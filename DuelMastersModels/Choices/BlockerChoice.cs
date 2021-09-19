using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class BlockerChoice : Choice
    {
        public IEnumerable<Creature> PossibleBlockers { get; }

        public BlockerChoice(IPlayer player) : base(player)
        {
        }
    }
}
