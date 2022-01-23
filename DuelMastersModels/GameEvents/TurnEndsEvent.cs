namespace DuelMastersModels.GameEvents
{
    public class TurnEndsEvent : GameEvent
    {
        public Turn Turn { get; }

        public TurnEndsEvent(Turn turn, Game game)
        {
            Turn = turn;
            Text = $"{Turn} ends for {game.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
