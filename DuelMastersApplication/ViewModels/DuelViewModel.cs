using DuelMastersModels;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersApplication.ViewModels
{
    class DuelViewModel
    {
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }

        /*public DuelViewModel(Duel duel)
        {
            Player1 = new PlayerViewModel(duel.Player1.Name);
            Player2 = new PlayerViewModel(duel.Player2.Name);
        }*/

        public void Update(Duel duel)
        {
            Player1.Update(duel, duel.Player1);
            Player2.Update(duel, duel.Player2);
        }

        public CardViewModel GetCard(int gameId)
        {
            return GetAllCards().First(c => c.GameId == gameId);
        }

        private List<CardViewModel> GetAllCards()
        {
            List<CardViewModel> cards = Player1.Cards.ToList();
            cards.AddRange(Player2.Cards.ToList());
            return cards;
        }
    }
}
