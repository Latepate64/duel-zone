using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace UnitTests
{
    public static class XmlUtility
    {
        public static string SerializeToString<T>(T value)
        {
            using (var stream = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true }))
                {
                    new XmlSerializer(value.GetType()).Serialize(writer, value, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
                    return stream.ToString();
                }
            }
        }
    }
}
