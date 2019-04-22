using System.Xml.Serialization;

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
        [XmlIgnore]
        public Player Player { get; set; }

        /// <summary>
        /// Identifier of the player performing the action.
        /// </summary>
        public int PlayerId
        {
            get { return Player.Id; }
            set { }
        }

        protected PlayerAction() { }

        protected PlayerAction(Player player)
        {
            Player = player;
            PlayerId = player.Id;
        }

        public abstract bool PerformAutomatically(Duel duel);
    }
}