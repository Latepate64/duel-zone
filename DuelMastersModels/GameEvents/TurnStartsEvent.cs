namespace DuelMastersModels.GameEvents
{
    public class TurnStartsEvent : GameEvent
    {
        public Turn Turn { get; }

        public TurnStartsEvent(Turn turn)
        {
            Turn = turn;
        }

        public override string ToString(Duel duel)
        {
            return $"{Turn} starts for {duel.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
