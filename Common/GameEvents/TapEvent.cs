using System.Collections.Generic;

namespace Common.GameEvents
{
    public class TapEvent : GameEvent
    {
        public Player Player { get; set; }

        public List<Card> Cards { get; set; }

        public bool TapInsteadOfUntap { get; set; }

        public TapEvent()
        {
        }

        public TapEvent(Player player, List<Card> cards, bool tapInsteadOfUntap)
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
