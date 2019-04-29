namespace DuelMastersServer.XMLMessages
{
    public class ChangeNameResponse : IXMLMessage
    {
        public string OldName { get; set; }
        public string NewName { get; set; }

        public ChangeNameResponse() { }

        public ChangeNameResponse(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }
    }
}
