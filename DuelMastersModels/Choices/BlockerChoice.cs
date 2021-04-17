using DuelMastersModels.Cards;
using System.Collections.Generic;

namespace DuelMastersModels.Choices
{
    public class BlockerChoice : Choice
    {
        public IEnumerable<IBattleZoneCreature> PossibleBlockers { get; }

        public BlockerChoice(IPlayer player) : base(player)
        {
        }
    }
}
