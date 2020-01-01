namespace DuelMastersModels.PlayerActionResponses
{
    /// <summary>
    /// Contains information whether a player takes an action or not.
    /// </summary>
    public class OptionalActionResponse : PlayerActionResponse
    {
        internal bool TakeAction { get; set; }

        /// <summary>
        /// Creates an optional action response.
        /// </summary>
        /// <param name="takeAction">Determines whether a player takes an action or not.</param>
        public OptionalActionResponse(bool takeAction)
        {
            TakeAction = takeAction;
        }
    }
}