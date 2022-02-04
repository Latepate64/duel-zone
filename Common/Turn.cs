using System;

namespace Common
{
    public class Turn
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 102.1. The active player is the player whose turn it is.
        /// </summary>
        public Player ActivePlayer { get; set; }

        /// <summary>
        /// 102.1. The other players are nonactive players.
        /// </summary>
        public Player NonActivePlayer { get; set; }

        /// <summary>
        /// The number of the turn.
        /// </summary>
        public int Number { get; set; }

        public Turn()
        {
            Id = Guid.NewGuid();
        }

        public Turn(Turn turn)
        {
            Id = turn.Id;
            ActivePlayer = turn.ActivePlayer;
            NonActivePlayer = turn.NonActivePlayer;
            Number = turn.Number;
        }

        public override string ToString()
        {
            return $"{ActivePlayer} turn no. {Number}";
        }
    }
}
