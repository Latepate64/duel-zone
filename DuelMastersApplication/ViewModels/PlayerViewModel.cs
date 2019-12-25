using DuelMastersModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersApplication.ViewModels
{
    public class PlayerViewModel
    {
        public string Name { get; private set; }

        public ZoneViewModel Hand { get; private set; } = new ZoneViewModel();
        public ZoneViewModel ManaZone { get; private set; } = new ZoneViewModel();
        public ZoneViewModel BattleZone { get; private set; } = new ZoneViewModel();
        public ZoneViewModel Deck { get; private set; } = new ZoneViewModel();
        public ZoneViewModel ShieldZone { get; private set; } = new ZoneViewModel();
        public ZoneViewModel Graveyard { get; private set; } = new ZoneViewModel();

        public ReadOnlyCollection<CardViewModel> Cards
        {
            get
            {
                List<CardViewModel> cards = new List<CardViewModel>();
                cards.AddRange(Hand.Cards);
                cards.AddRange(ManaZone.Cards);
                cards.AddRange(BattleZone.Cards);
                cards.AddRange(Deck.Cards);
                cards.AddRange(ShieldZone.Cards);
                cards.AddRange(Graveyard.Cards);
                return new ReadOnlyCollection<CardViewModel>(cards);
            }
        }

        public PlayerViewModel(string name)
        {
            Name = name;
        }

        public void Update(Duel duel, Player player)
        {
            Hand.Update(duel, player.Hand);
            ManaZone.Update(duel, player.ManaZone);
            BattleZone.Update(duel, player.BattleZone);
            Deck.Update(duel, player.Deck);
            ShieldZone.Update(duel, player.ShieldZone);
            Graveyard.Update(duel, player.Graveyard);
        }
    }
}
