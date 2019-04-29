namespace DuelMastersServer.XMLMessages
{
    public class ChangeNameRequest : IXMLMessage
    {
        public string Name { get; set; }

        public ChangeNameRequest() { }

        public ChangeNameRequest(string name)
        {
            Name = name;
        }
    }
}