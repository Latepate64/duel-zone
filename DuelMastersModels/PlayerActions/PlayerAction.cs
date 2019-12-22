//using System.Xml.Serialization;
namespace DuelMastersModels.PlayerActions
{
    /// <summary>
    /// Represents an action a player must perform.
    /// </summary>
    public abstract class PlayerAction
    {
        /// <summary>
        /// Player performing the action.
        /// </summary>
        //[XmlIgnore]
        public Player Player { get; set; }

        /// <summary>
        /// Identifier of the player performing the action.
        /// </summary>
        public int PlayerId => Player.Id;

        protected PlayerAction() { }

        protected PlayerAction(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// Tries to perform the player action automatically if possible. Returns the player action itself if it is not possible to perform action automatically, otherwise returns new player action based on what happened during the automatic performance (may return null, in that case the performance does not require further player actions).
        /// </summary>
        /// <param name="duel"></param>
        /// <returns></returns>
        public abstract PlayerAction TryToPerformAutomatically(Duel duel);
    }
}