namespace DuelMastersServer.XMLMessages
{
    public class ClientConnect : IXMLMessage
    {
        public string Name { get; set; }

        public ClientConnect() { }

        public ClientConnect(string name)
        {
            Name = name;
        }
    }
}