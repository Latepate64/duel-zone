using System.Collections.Generic;

namespace DuelMastersServer.XMLMessages
{
    public class ConnectionResponse : IXMLMessage
    {
        public string Name { get; set; }

        [System.Xml.Serialization.XmlArrayItem("C")]
        public List<string> Clients { get; set; }

        public ConnectionResponse() { }

        public ConnectionResponse(string name, List<string> clients)
        {
            Name = name;
            Clients = clients;
        }
    }
}
