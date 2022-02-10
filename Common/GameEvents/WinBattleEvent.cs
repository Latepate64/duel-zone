namespace Common.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Card Creature { get; set; }

        public WinBattleEvent()
        {
        }

        public override string ToString()
        {
            return $"{Creature} won the battle.";
        }
    }
}
