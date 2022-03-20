using System.Collections.Generic;

namespace Common.GameEvents
{
    public class RevealEvent : GameEvent
    {
        public IPlayer Revealer { get; set; }
        public List<IPlayer> RevealedTo { get; set; }
        public List<ICard> Cards { get; set; }

        public RevealEvent()
        {
        }

        public override string ToString()
        {
            return $"{Revealer} revealed {string.Join(", ", Cards)} to {string.Join(", ", RevealedTo)}.";
        }
    }
}
