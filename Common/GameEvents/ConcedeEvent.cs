namespace Common.GameEvents
{
    public class ConcedeEvent : GameEvent
    {
        public IPlayer Player { get; set; }

        public ConcedeEvent()
        {
        }

        public override string ToString()
        {
            return $"{Player} conceded the game.";
        }
    }
}
