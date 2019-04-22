using DuelMastersModels.Cards;
using System;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public class ChargeMana : OptionalCardSelection
    { 
        public ChargeMana() { }

        public ChargeMana(Player player) : base(player, player.Hand.Cards)
        { }

        public override void Perform(Duel duel, Card card)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            if (card != null)
            {
                duel.PutFromHandIntoManaZone(Player, card);
            }
        }
    }
}
