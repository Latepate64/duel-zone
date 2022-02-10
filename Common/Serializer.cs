using System;
using System.Collections.Generic;
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

        //https://www.generacodice.com/en/articolo/2837816/xml-parser,-multiple-roots
        public static List<object> Deserialize(string text)
        {
            var objects = new List<object>();
            var readerSettings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
            using (var reader = XmlReader.Create(new StringReader(text), readerSettings))
            {
                while (reader.Read())
                {
                    using var fragmentReader = reader.ReadSubtree();
                    if (fragmentReader.Read())
                    {
                        var fragment = XNode.ReadFrom(fragmentReader) as XElement;
                        objects.Add(new XmlSerializer(GetCorrectType(fragment.Name)).Deserialize(fragment.CreateReader()));
                    }
                }
            }
            return objects;
        }

        private static Type GetCorrectType(XName name)
        {
            var namespaces = new List<string> { "", "Choices.", "GameEvents." };
            foreach (var ns in namespaces)
            {
                var typeName = $"Common.{ns}{name}";
                var type = Type.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
