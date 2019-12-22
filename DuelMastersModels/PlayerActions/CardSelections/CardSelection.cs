using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace DuelMastersModels.PlayerActions.CardSelections
{
    public abstract class CardSelection : PlayerAction
    {
        [XmlIgnore]
        public ReadOnlyCardCollection Cards { get; private set; }

        [XmlArrayItem(ElementName = "CardId")]
        public Collection<int> CardIds { get; private set; }

        [XmlIgnore]
        public int MinimumSelection { get; set; }

        [XmlIgnore]
        public int MaximumSelection { get; set; }

        protected CardSelection() { }

        protected CardSelection(Player player, int minimumSelection, int maximumSelection, ReadOnlyCardCollection cards) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Cards = cards;
            CardIds = new Collection<int>(cards.Select(card => card.GameId).ToList());
        }
    }
}
