namespace DuelMastersServer.XMLMessages
{
    public class ChallengePendingResponse : IXMLMessage
    {
        public string ChallengeeName { get; set; }

        public ChallengePendingResponse() { }
    }
}