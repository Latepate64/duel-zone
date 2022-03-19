namespace Common.GameEvents
{
    public class BattleEvent : CardEvent
    {
        public ICard OtherCard { get; set; }

        public BattleEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} ({Card.Power}) battled {OtherCard} ({OtherCard.Power}).";
        }
    }
}
