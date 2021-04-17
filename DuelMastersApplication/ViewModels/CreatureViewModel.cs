using DuelMastersModels;
using DuelMastersModels.Cards;
using System.Collections.ObjectModel;

namespace DuelMastersApplication.ViewModels
{
    public class CreatureViewModel : CardViewModel
    {
        private int _power;
        public int Power 
        { 
            get
            {
                return _power;
            }
            private set
            {
                if (value != _power)
                {
                    _power = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> Races { get; } = new ObservableCollection<string>();

        public CreatureViewModel(Creature creature, Duel duel) : base(creature)
        {
            Power = duel.GetPower(creature);
            Races = new ObservableCollection<string>(creature.Races);
        }

        public override void Update(Card card, Duel duel)
        {
            UpdateCard(card);
            Creature creature = card as Creature;
            Power = duel.GetPower(creature);
            //TODO
            //Races = creature.Races;
        }
    }
}
