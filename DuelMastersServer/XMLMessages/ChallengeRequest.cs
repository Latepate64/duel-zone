namespace DuelMastersServer.XMLMessages
{
    public class ChallengeRequest : IXMLMessage
    {
        public string ChallengeeName { get; set; }

        public ChallengeRequest() { }

        public ChallengeRequest(string challengeeName)
        {
            ChallengeeName = challengeeName;
        }
    }
}
