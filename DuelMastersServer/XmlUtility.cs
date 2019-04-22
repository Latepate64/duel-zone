using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DuelMastersServer
{
    public static class XmlUtility
    {
        public static string SerializeToString<T>(T value)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
            using (var stream = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, value, emptyNamepsaces);
                    return stream.ToString();
                }
            }
        }
    }
}
