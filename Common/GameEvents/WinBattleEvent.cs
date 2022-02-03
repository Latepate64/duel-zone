namespace Common.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Card Creature { get; }

        public WinBattleEvent(Card creature)
        {
            Creature = creature;
            //Text = $"{game.GetOwner(Creature)}'s {Creature} won the battle.";
        }
    }
}
