namespace DuelMastersModels.PlayerActionResponses
{
    public class OptionalActionResponse : PlayerActionResponse
    {
        public bool TakeAction { get; set; }

        public OptionalActionResponse(bool takeAction)
        {
            TakeAction = takeAction;
        }
    }
}