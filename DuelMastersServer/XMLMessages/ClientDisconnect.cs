namespace DuelMastersServer.XMLMessages
{
    public class ClientDisconnect : IXMLMessage
    {
        public string Name { get; set; }

        public ClientDisconnect() { }

        public ClientDisconnect(string name)
        {
            Name = name;
        }
    }
}
