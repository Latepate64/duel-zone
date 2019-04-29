namespace DuelMastersServer.XMLMessages
{
    public class ErrorResponse : IXMLMessage
    {
        public int ErrorCode { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(int errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
