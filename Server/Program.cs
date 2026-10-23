using System.Xml.Serialization;

const string path = @"..\..\..\cards.xml";
var serializer = new XmlSerializer(typeof(Root));
using Stream reader = new FileStream(path, FileMode.Open);
var cards = serializer.Deserialize(reader);
Console.WriteLine("Hello world!");
