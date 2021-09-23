using DuelMastersModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class AttackerChoice : Choice
    {
        public IEnumerable<IGrouping<Creature, IEnumerable<IAttackable>>> Options { get; }

        public IGrouping<Creature, IAttackable> Selected { get; set; }

        public AttackerChoice(Player player, IEnumerable<IGrouping<Creature, IEnumerable<IAttackable>>> options) : base(player)
        {
            Options = options;
        }
    }
}
