namespace DuelMastersServer.XMLMessages
{
    public class SendMessage : IXMLMessage
    {
        public string Text { get; set; }

        public SendMessage() { }

        public SendMessage(string text)
        {
            Text = text;
        }
    }
}
