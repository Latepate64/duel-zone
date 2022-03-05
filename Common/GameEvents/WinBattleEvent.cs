namespace Common.GameEvents
{
    public class WinBattleEvent : CardEvent
    {
        public WinBattleEvent()
        {
        }

        public override string ToString()
        {
            return $"{Card} won the battle.";
        }
    }
}
