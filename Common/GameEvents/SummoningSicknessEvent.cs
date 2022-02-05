using System.Collections.Generic;

namespace Common.GameEvents
{
    public class SummoningSicknessEvent : GameEvent
    {
        public List<Card> Cards { get; set; }

        public SummoningSicknessEvent()
        {
        }
    }
}
