using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Common
{
    public static class Serializer
    {
        public static string Serialize<T>(T value)
        {
            using StringWriter stream = new(CultureInfo.InvariantCulture);
            using XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true });
            new XmlSerializer(value.GetType()).Serialize(writer, value, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
            return stream.ToString();
        }

        public static object Deserialize(string text)
        {
            XElement xElement = XElement.Parse(text);
            return new XmlSerializer(Type.GetType($"Common.{xElement.Name}", true)).Deserialize(xElement.CreateReader());
        }
    }
}
