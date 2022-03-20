using System.Collections.Generic;

namespace Common.GameEvents
{
    public class SummoningSicknessEvent : GameEvent
    {
        public List<ICard> Cards { get; set; }

        public SummoningSicknessEvent()
        {
        }

        public override string ToString()
        {
            return $"{string.Join(", ", Cards)} lost summoning sickness.";
        }
    }
}
