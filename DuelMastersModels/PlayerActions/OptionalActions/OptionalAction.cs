using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMastersModels.PlayerActions.OptionalActions
{
    public abstract class OptionalAction : PlayerAction
    {
        protected OptionalAction(Player player) : base(player) { }

        public override bool PerformAutomatically(Duel duel)
        {
            return false;
        }

        public abstract PlayerAction Perform(Duel duel, bool takeAction);
    }
}
