using System;

namespace Common.GameEvents
{
    public class TurnEndsEvent : GameEvent
    {
        public Guid Turn { get; }

        public TurnEndsEvent(Guid turn)
        {
            Turn = turn;
            //Text = $"{Turn} ends for {game.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
