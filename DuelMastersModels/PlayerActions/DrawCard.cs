using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelMastersModels.PlayerActions
{
    public class DrawCard : PlayerAction
    {
        public DrawCard(Player player) : base(player)
        {
        }

        public override bool PerformAutomatically(Duel duel)
        {
            Perform(duel);
            return true;
        }

        public void Perform(Duel duel)
        {
            Duel.DrawCard(Player);
        }
    }
}
