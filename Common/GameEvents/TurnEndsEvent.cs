using System;

namespace Common.GameEvents
{
    public class TurnEndsEvent : GameEvent
    {
        public Guid Turn { get; set; }

        public TurnEndsEvent()
        {
            //Text = $"{Turn} ends for {game.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
