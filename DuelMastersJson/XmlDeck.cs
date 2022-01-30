using System.Collections.Generic;
using System.Xml.Serialization;

namespace Json
{
    /// <summary>
    /// Represents a deck that a player can have.
    /// </summary>
    [XmlRoot("Deck")]
    public class XmlDeck
    {
        /// <summary>
        /// Cards the deck contains.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [XmlElement("Card")]
        public List<XmlCard> Card { get; set; }
    }

    /// <summary>
    /// Identifies a card and contains information how many instances of the card there are.
    /// </summary>
    public class XmlCard
    {
        /// <summary>
        /// The set of the card. (eg. DM-01 Base Set)
        /// </summary>
        [XmlElement("Set")]
        public string Set { get; set; }

        /// <summary>
        /// The identifier of the card. (eg. 23/110)
        /// </summary>
        [XmlElement("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Specifies the amount of cards there are.
        /// </summary>
        [XmlElement("Amount")]
        public int Amount { get; set; }
    }
}
