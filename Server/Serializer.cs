using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Server
{
    internal static class Serializer
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
            //var foo = $"{xElement.Name}, DuelMasters.Common";
            //var foo = $"{xElement.Name}, DuelMasters.Common";
            var foo = $"Common.{xElement.Name}";
            var foo1 = Type.GetType(foo, true);
            var foo2 = new XmlSerializer(foo1);
            return foo2.Deserialize(xElement.CreateReader());
        }
    }
}
