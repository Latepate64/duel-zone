namespace DuelMastersModels.GameEvents
{
    public class TurnEndsEvent : GameEvent
    {
        public Turn Turn { get; }

        public TurnEndsEvent(Turn turn)
        {
            Turn = turn;
        }

        public override string ToString(Game game)
        {
            return $"{Turn} ends for {game.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
