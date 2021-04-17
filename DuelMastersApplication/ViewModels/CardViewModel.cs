using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DuelMastersApplication.ViewModels
{
    public abstract class CardViewModel : INotifyPropertyChanged
    {
        #region Properties
        public int GameId { get; protected set; }

        public string Name { get; private set; }
        public string Set { get; private set; }
        public string Id { get; private set; }
        public ReadOnlyCivilizationCollection Civilizations { get; }
        public Rarity Rarity { get; private set; }
        public int Cost { get; private set; }
        public string Text { get; private set; }

        public bool KnownToPlayerWithPriority { get; private set; }
        public bool KnownToPlayerWithoutPriority { get; private set; }

        private bool _tapped;
        public bool Tapped
        {
            get => _tapped;
            set
            {
                if (value != _tapped)
                {
                    _tapped = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion Properties

        protected CardViewModel(Card card)
        {  
            GameId = card.GameId;

            //TODO: Civilizations to UpdateCard()
            Civilizations = card.Civilizations;

            UpdateCard(card);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract void Update(Card card, DuelMastersModels.Duel duel);

        protected void UpdateCard(Card card)
        {
            Name = card.Name;
            Rarity = card.Rarity;
            Cost = card.Cost;
            Text = card.Text;
            Set = card.Set;
            Id = card.Id;
            KnownToPlayerWithPriority = card.KnownToPlayerWithPriority;
            KnownToPlayerWithoutPriority = card.KnownToPlayerWithoutPriority;
            Tapped = card.Tapped;
        }

        protected void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
