using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace DuelMastersModels.PlayerActions.CreatureSelections
{
    public abstract class CreatureSelection : PlayerAction
    {
        [XmlIgnore]
        public ReadOnlyCreatureCollection Creatures { get; private set; }

        [XmlArrayItem(ElementName = "CreatureId")]
        public Collection<int> CreatureIds { get; private set; }

        [XmlIgnore]
        public int MinimumSelection { get; set; }

        [XmlIgnore]
        public int MaximumSelection { get; set; }

        protected CreatureSelection() { }

        protected CreatureSelection(Player player, int minimumSelection, int maximumSelection, ReadOnlyCreatureCollection creatures) : base(player)
        {
            MinimumSelection = minimumSelection;
            MaximumSelection = maximumSelection;
            Creatures = creatures;
            CreatureIds = new Collection<int>(creatures.Select(card => card.GameId).ToList());
        }
    }
}
