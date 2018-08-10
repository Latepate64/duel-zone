using DuelMastersModels.Cards;

namespace DuelMastersModels.PlayerActions
{
    public class ChargeMana : PlayerAction
    {
        public Card SelectedCard { get; set; }

        public ChargeMana(Player player) : base(player)
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
