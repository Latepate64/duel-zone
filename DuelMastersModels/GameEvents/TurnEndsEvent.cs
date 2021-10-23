namespace DuelMastersModels.GameEvents
{
    public class TurnEndsEvent : GameEvent
    {
        public Turn Turn { get; }

        public TurnEndsEvent(Turn turn)
        {
            Turn = turn;
        }

        public override string ToString(Duel duel)
        {
            return $"{Turn} ends for {duel.GetPlayer(Turn.ActivePlayer).Name}.";
        }
    }
}
