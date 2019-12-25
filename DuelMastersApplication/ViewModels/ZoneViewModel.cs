using DuelMastersModels.Cards;
using DuelMastersModels.Zones;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersApplication.ViewModels
{
    public class ZoneViewModel
    {
        public ObservableCollection<CardViewModel> Cards { get; } = new ObservableCollection<CardViewModel>();

        public void Update(DuelMastersModels.Duel duel, Zone zone)
        {
            foreach (Card cardToAdd in zone.Cards.Where(handCard => Cards.All(viewModelCard => viewModelCard.GameId != handCard.GameId)))
            {
                if (cardToAdd is Creature creature)
                {
                    Cards.Add(new CreatureViewModel(creature, duel));
                }
                else if (cardToAdd is Spell spell)
                {
                    Cards.Add(new SpellViewModel(spell));
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
            System.Collections.Generic.IEnumerable<CardViewModel> cardsToRemove = Cards.Where(viewModelCard => zone.Cards.All(handCard => handCard.GameId != viewModelCard.GameId));
            while (cardsToRemove.Count() > 0)
            {
                Cards.Remove(cardsToRemove.First());
            }

            for (int i = 0; i < Cards.Count; ++i)
            {
                Cards[i].Update(zone.Cards[i], duel);
            }
        }
    }
}
