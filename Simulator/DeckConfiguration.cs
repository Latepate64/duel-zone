using System.Xml.Serialization;

namespace Simulator
{
    [XmlRoot("deck")]
    public class DeckConfiguration
    {
        [XmlElement("section")]
        public Section[] Sections { get; set; }
    }

    public class Section
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("card")]
        public CardConfiguration[] Cards { get; set; }
    }

    public class CardConfiguration
    {
        [XmlAttribute("qty")]
        public int Quantity { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}
