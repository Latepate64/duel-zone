using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersModels.PlayerActions
{
    public class ChargeMana : OptionalCardSelection
    {
        public ChargeMana(Player player, Collection<Card> cards) : base(player, cards)
        { }

        public override void Perform(Duel duel)
        {
            if (duel == null)
            {
                throw new System.ArgumentNullException("duel");
            }
            if (SelectedCard != null)
            {
                Duel.PutFromHandToManaZone(Player, SelectedCard);
            }
        }
    }
}
