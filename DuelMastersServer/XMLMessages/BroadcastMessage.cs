namespace DuelMastersServer.XMLMessages
{
    public class BroadcastMessage : IXMLMessage
    {
        public string Sender { get; set; }
        public string Text { get; set; }

        public BroadcastMessage() { }

        public BroadcastMessage(string sender, string text)
        {
            Sender = sender;
            Text = text;
        }
    }
}
