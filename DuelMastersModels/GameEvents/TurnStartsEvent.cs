namespace DuelMastersModels.GameEvents
{
    public class TurnStartsEvent : GameEvent
    {
        public Turn Turn { get; }

        public TurnStartsEvent(Turn turn, Game game)
        {
            Turn = turn;
            Text = $"{Turn} starts for {game.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
