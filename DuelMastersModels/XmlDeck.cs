using System.Collections.Generic;
using System.Xml.Serialization;

namespace DuelMastersModels
{
    [XmlRoot("Deck")]
    public class XmlDeck
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [XmlElement("Card")]
        public List<XmlCard> Card { get; set; }
    }

    public class XmlCard
    {
        [XmlElement("Set")]
        public string Set { get; set; }
        [XmlElement("Id")]
        public string Id { get; set; }
        [XmlElement("Amount")]
        public int Amount { get; set; }
    }
}
