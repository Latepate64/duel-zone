using System.Xml.Linq;

namespace DuelMastersClient
{
    public static class XmlUtility
    {
        public static XElement GetXElement(string text)
        {
            return XElement.Parse(text);
        }
    }
}
