namespace Common.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Card Creature { get; set; }

        public WinBattleEvent()
        {
            //Text = $"{game.GetOwner(Creature)}'s {Creature} won the battle.";
        }
    }
}
