using System;

namespace Common
{
    public class Turn : ITurn
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The number of the turn.
        /// </summary>
        public int Number { get; set; }

        public Turn()
        {
            Id = Guid.NewGuid();
        }

        public Turn(ITurn turn)
        {
            Id = turn.Id;
            Number = turn.Number;
        }

        public override string ToString()
        {
            return $"Turn no. {Number}";
        }
    }
}
