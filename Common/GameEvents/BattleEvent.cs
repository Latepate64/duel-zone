namespace Common.GameEvents
{
    public class BattleEvent : GameEvent
    {
        public Card Creature1 { get; set; }
        public Card Creature2 { get; set; }

        public BattleEvent()
        {
        }

        public override string ToString()
        {
            return $"{Creature1} ({Creature1.Power}) battled {Creature2} ({Creature2.Power}).";
        }
    }
}
