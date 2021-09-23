using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Choices
{
    public class AttackerChoice : Choice
    {
        public IEnumerable<IGrouping<Creature, IEnumerable<IAttackable>>> Options { get; }

        public Tuple<Creature, IAttackable> Selected { get; set; }

        public AttackerChoice(Player player, IEnumerable<IGrouping<Creature, IEnumerable<IAttackable>>> options) : base(player)
        {
            Options = options;
        }

        public AttackerChoice(Tuple<Creature, IAttackable> selected) : base(null)
        {
            Selected = selected;
        }
    }
}
