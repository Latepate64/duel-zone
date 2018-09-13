namespace DuelMastersClient
{
    class XmlMessage
    {
        public string Type { get; private set; }
        public string Data { get; private set; }

        public XmlMessage(string type, string data)
        {
            Type = type;
            Data = data;
        }
    }
}
