using System.Xml.Serialization;
using Server;


const string path = @"..\..\..\cards.xml";
var serializer = new XmlSerializer(typeof(CardsContainer));
using Stream reader = new FileStream(path, FileMode.Open);
var cards = serializer.Deserialize(reader);
Console.WriteLine("Hello world!");
