namespace DuelMastersModels.GameEvents
{
    public class TurnStartsEvent : GameEvent
    {
        public Turn Turn { get; }

        public TurnStartsEvent(Turn turn)
        {
            Turn = turn;
        }

        public override string ToString(Game game)
        {
            return $"{Turn} starts for {game.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
