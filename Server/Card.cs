using System.Xml.Serialization;

namespace Server;

[XmlRoot(ElementName = "root")]
public class CardsContainer
{
    [XmlArray("cards")]
    [XmlArrayItem("creature", typeof(Creature))]
    [XmlArrayItem("spell", typeof(Spell))]
    public required Card[] Cards { get; set; }
}

public class Card
{
    [XmlElement("name")]
    public required string Name { get; set; }
}

public class Creature : Card
{
    [XmlElement("power")]
    public required string Power { get; set; }
}

public class Spell : Card
{
}