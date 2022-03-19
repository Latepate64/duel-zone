using System.Collections.Generic;

namespace Common.GameEvents
{
    public class TapEvent : GameEvent
    {
        public IPlayer Player { get; set; }

        public List<ICard> Cards { get; set; }

        public bool TapInsteadOfUntap { get; set; }

        public TapEvent()
        {
        }

        public TapEvent(IPlayer player, List<ICard> cards, bool tapInsteadOfUntap)
        {
            Player = player;
            Cards = cards;
            TapInsteadOfUntap = tapInsteadOfUntap;
        }

        public override string ToString()
        {
            return $"{Player} {(TapInsteadOfUntap ? "" : "un")}tapped {string.Join(", ", Cards)}.";
        }
    }
}
