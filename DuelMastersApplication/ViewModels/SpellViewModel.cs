using DuelMastersModels;
using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersApplication.ViewModels
{
    public class SpellViewModel : CardViewModel
    {
        public SpellViewModel(Spell spell) : base(spell)
        {
        }

        public override void Update(Card card, Duel duel)
        {
            UpdateCard(card);
        }
    }
}
