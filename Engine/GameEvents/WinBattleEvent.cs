namespace Engine.GameEvents
{
    public class WinBattleEvent : GameEvent
    {
        public Card Creature { get; }

        public WinBattleEvent(Card creature, Game game)
        {
            Creature = creature;
            Text = $"{game.GetOwner(Creature)}'s {Creature} won the battle.";
        }
    }
}
